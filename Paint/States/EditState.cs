using Paint.Interfaces;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Paint.Figures;

namespace Paint.States;

internal class EditState : IState, ISelection {
    public List<IDrawable> Figures { get; set; } = [];
    public List<IDrawable> SelectedFigures { get; set; } = [];

    public bool IsMoving { get; set; } = false;
    public Size CanvasSize { get; set; }
    public Point DragStartPoint { get; set; } = new Point(0, 0);
    public Dictionary<ResizePointsEnum, Point> ResizePointsDict { get; set; } = [];
    public ResizePointsEnum? CurrentResizePoint { get; set; } = null;

    public void UpdateResizePointsDict() {
        var topLeftPoint = this.SelectedFigures[0].TopPoint;
        var botRightPoint = this.SelectedFigures[0].BotPoint;
        var topRightPoint = new Point(botRightPoint.X, topLeftPoint.Y);
        var botLeftPoint = new Point(topLeftPoint.X, botRightPoint.Y);

        var middleX = topLeftPoint.X + (topRightPoint.X - topLeftPoint.X) / 2;
        var middleY = topLeftPoint.Y + (botLeftPoint.Y - topLeftPoint.Y) / 2;

        var middleLeftPoint = new Point(topLeftPoint.X, middleY);
        var middleTopPoint = new Point(middleX, topLeftPoint.Y);
        var middleRightPoint = new Point(botRightPoint.X, middleY);
        var middleBotPoint = new Point(middleX, botRightPoint.Y);

        this.ResizePointsDict[ResizePointsEnum.TopLeft] = topLeftPoint;
        this.ResizePointsDict[ResizePointsEnum.BotRight] = botRightPoint;
        this.ResizePointsDict[ResizePointsEnum.TopRight] = topRightPoint;
        this.ResizePointsDict[ResizePointsEnum.BotLeft] = botLeftPoint;
        this.ResizePointsDict[ResizePointsEnum.MiddleLeft] = middleLeftPoint;
        this.ResizePointsDict[ResizePointsEnum.MiddleTop] = middleTopPoint;
        this.ResizePointsDict[ResizePointsEnum.MiddleRight] = middleRightPoint;
        this.ResizePointsDict[ResizePointsEnum.MiddleBot] = middleBotPoint;
    }

    public void MouseDownHandler(MouseEventArgs e) {
        this.DragStartPoint = new Point(e.X, e.Y);
        var point = new Point(e.X, e.Y);
        if (e.Button == MouseButtons.Left) {
            bool isContains = false;
            foreach (IDrawable figure in this.Figures) {
                if (figure.ContainsPoint(point)) {
                    isContains = true;
                    if (!this.SelectedFigures.Contains(figure) && this.SelectedFigures.Count == 0) {
                        this.SelectedFigures.Add(figure);
                        break;
                    }
                }
            }

            if (!isContains) {
                this.SelectedFigures.Clear();
            }

            if (this.SelectedFigures.Count == 1) {
                UpdateResizePointsDict();
                this.SelectedFigures[0].ResizePointsDict = this.ResizePointsDict;
                foreach (var (key, value) in this.SelectedFigures[0].GetResizeCircles()) {
                    if (value.ContainsPoint(point)) {
                        CurrentResizePoint = key;
                        break;
                    }
                } 
            }

            this.IsMoving = true;
        }

        if (e.Button == MouseButtons.Right) {
            foreach (IDrawable figure in this.Figures) {
                if (figure.ContainsPoint(point) && this.SelectedFigures.Contains(figure)) {
                    _ = this.SelectedFigures.Remove(figure);
                    break;
                }
            }
        }
    }

    public void MouseMoveHandler(MouseEventArgs e) {
        if (this.IsMoving && this.SelectedFigures.Count == 1) {
            UpdateResizePointsDict();

            int dx = e.X - this.DragStartPoint.X;
            int dy = e.Y - this.DragStartPoint.Y;

            this.SelectedFigures[0].ResizePointsDict = this.ResizePointsDict;

            if (CurrentResizePoint is not null) {
                if (CurrentResizePoint == ResizePointsEnum.TopLeft) {
                    this.SelectedFigures[0].TopPoint = new Point(this.SelectedFigures[0].TopPoint.X + dx, this.SelectedFigures[0].TopPoint.Y + dy);
                }

                if (CurrentResizePoint == ResizePointsEnum.TopRight) {
                    this.SelectedFigures[0].TopPoint = new Point(this.SelectedFigures[0].TopPoint.X, this.SelectedFigures[0].TopPoint.Y + dy);
                    this.SelectedFigures[0].BotPoint = new Point(this.SelectedFigures[0].BotPoint.X + dx, this.SelectedFigures[0].BotPoint.Y);
                }

                if (CurrentResizePoint == ResizePointsEnum.BotRight) {
                    this.SelectedFigures[0].BotPoint = new Point(this.SelectedFigures[0].BotPoint.X + dx, this.SelectedFigures[0].BotPoint.Y + dy);
                }

                if (CurrentResizePoint == ResizePointsEnum.BotLeft) {
                    this.SelectedFigures[0].TopPoint = new Point(this.SelectedFigures[0].TopPoint.X + dx, this.SelectedFigures[0].TopPoint.Y);
                    this.SelectedFigures[0].BotPoint = new Point(this.SelectedFigures[0].BotPoint.X, this.SelectedFigures[0].BotPoint.Y + dy);
                }

                if (CurrentResizePoint == ResizePointsEnum.MiddleTop) {
                    this.SelectedFigures[0].TopPoint = new Point(this.SelectedFigures[0].TopPoint.X, this.SelectedFigures[0].TopPoint.Y + dy);
                }

                if (CurrentResizePoint == ResizePointsEnum.MiddleRight) {
                    this.SelectedFigures[0].BotPoint = new Point(this.SelectedFigures[0].BotPoint.X + dx, this.SelectedFigures[0].BotPoint.Y);
                }

                if (CurrentResizePoint == ResizePointsEnum.MiddleBot) {
                    this.SelectedFigures[0].BotPoint = new Point(this.SelectedFigures[0].BotPoint.X, this.SelectedFigures[0].BotPoint.Y + dy);
                }

                if (CurrentResizePoint == ResizePointsEnum.MiddleLeft) {
                    this.SelectedFigures[0].TopPoint = new Point(this.SelectedFigures[0].TopPoint.X + dx, this.SelectedFigures[0].TopPoint.Y);
                }

                if (this.SelectedFigures[0] is StraightLineWrapper line) {
                    line.CalculateStartEndPoints();
                }

                this.DragStartPoint = new Point(e.X, e.Y);

                return;
            }

            foreach (IDrawable figure in this.SelectedFigures) {
                figure.ValidateEdgePoint();
                if (!figure.CanMove(dx, dy, this.CanvasSize)) {
                    return;
                }
            }

            foreach (IDrawable figure in this.SelectedFigures) {
                figure.Move(dx, dy);
                this.DragStartPoint = new Point(e.X, e.Y);
            }
        }
    }

    public void MouseUpHandler(MouseEventArgs e) {
        if (this.SelectedFigures.Count == 1) {
            UpdateResizePointsDict();
            this.SelectedFigures[0].ResizePointsDict = this.ResizePointsDict;
        }
        this.CurrentResizePoint = null;
        this.IsMoving = false;
    }
}
