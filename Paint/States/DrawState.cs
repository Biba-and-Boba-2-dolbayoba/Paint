using Paint.Figures;
using Paint.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Paint.States;

internal class DrawState : IState, IDrawing {
    public bool IsDrawing { get; set; } = false;

    public Point TopPoint { get; set; }
    public Point BotPoint { get; set; }

    public List<Point> Points { get; set; } = [];
    private int Counter { get; set; } = 0;

    public Size CanvasSize { get; set; }

    public int PenSize { get; set; }
    public Color PenColor { get; set; }
    public Color BrushColor { get; set; }
    public bool IsFilling { get; set; }

    public string Text { get; set; } = "";
    public Font TextFont { get; set; } = new Font("Times New Roman", 12.0f);

    public FigureTypes FigureType { get; set; } = FigureTypes.Rectangle;
    public IDrawable? DashFigure { get; set; } = null;
    public List<IDrawable> Figures { get; set; } = [];

    public CanvasForm? ParentReference { get; set; }
    public BufferedGraphics? GraphicsBuffer { get; set; }

    public int GridStep { get; set; } = 10;
    public bool SnapToGrid { get; set; } = false;

    private TextBoxWrapper? Wrapper { get; set; }
    private TextBox? TextBox { get; set; }

    private static Dictionary<FigureTypes, Type> WrapperTypes { get; set; } = new() {
        { FigureTypes.Rectangle, typeof(RectangleWrapper) },
        { FigureTypes.Ellipse, typeof(EllipseWrapper) },
        { FigureTypes.StraightLine, typeof(StraightLineWrapper) },
        { FigureTypes.CurveLine, typeof(CurveLineWrapper) },
        { FigureTypes.TextBox, typeof(TextBoxWrapper) },
    };
    private Point GetNearestGridPoint(Point point) {
        if (!this.SnapToGrid) {
            return point;
        }

        int x = (int)Math.Round((double)point.X / this.GridStep) * this.GridStep;
        int y = (int)Math.Round((double)point.Y / this.GridStep) * this.GridStep;
        return new Point(x, y);
    }

    public void MouseDownHandler(MouseEventArgs e) {
        if (e.Button == MouseButtons.Left && !this.IsDrawing) {

            this.TopPoint = this.SnapToGrid ? this.GetNearestGridPoint(new Point(e.X, e.Y)) : new Point(e.X, e.Y);
            this.BotPoint = this.TopPoint;

            this.IsDrawing = true;

            if (this.FigureType == FigureTypes.CurveLine) {
                this.Points.Clear(); // Очистка массива говна
                this.Points.Add(this.TopPoint);  // начальная точка 
            }
        }
    }

    public void MouseMoveHandler(MouseEventArgs e) {
        if (e.Button == MouseButtons.Left && this.IsDrawing) {
            // this.BotPoint = SnapToGrid ? GetNearestGridPoint(new Point(e.X, e.Y)) : new Point(e.X, e.Y);
            this.BotPoint = new Point(e.X, e.Y);

            var wrapper = (IDrawable?)Activator.CreateInstance(WrapperTypes[this.FigureType]);

            if (wrapper is not null) {
                wrapper.PenSize = this.PenSize;
                wrapper.PenColor = this.PenColor;
                wrapper.BrushColor = this.BrushColor;
                wrapper.TopPoint = this.TopPoint;
                wrapper.BotPoint = this.BotPoint;
                wrapper.IsFilling = this.IsFilling;
                wrapper.FigureType = this.FigureType;

                if (wrapper is StraightLineWrapper straightLineWrapper) {
                    straightLineWrapper.StartPoint = new Point(this.TopPoint.X, this.TopPoint.Y);
                    straightLineWrapper.EndPoint = new Point(this.BotPoint.X, this.BotPoint.Y);
                }

                if (wrapper is CurveLineWrapper curveLineWrapper) {
                    if (this.Counter % 4 == 0) {
                        this.Points.Add(this.BotPoint);
                    } else {
                        ++this.Counter;
                    }

                    curveLineWrapper.Points = new List<Point>(this.Points);
                }

                if (wrapper is TextBoxWrapper textBoxWrapper) {
                    textBoxWrapper.Text = this.Text;
                    textBoxWrapper.TextFont = this.TextFont;
                }
            }

            if (this.BotPoint.X < this.CanvasSize.Width && this.BotPoint.Y < this.CanvasSize.Height) {
                this.DashFigure = wrapper;
            }
        }
    }

    private void OnTextBoxKeyDown(object? sender, KeyEventArgs e) {
        if (e.Shift && e.KeyCode == Keys.Enter && this.TextBox is not null && this.Wrapper is not null && this.ParentReference is not null) {
            this.TextBox.ReadOnly = true;
            this.TextBox.Visible = false;
            this.Wrapper.Text = this.TextBox.Text;
            this.Figures.Add(this.Wrapper);
            this.ParentReference.Figures = this.Figures;
            this.TextBox.Dispose();
        }
    }

    public void MouseUpHandler(MouseEventArgs e) {
        if (e.Button == MouseButtons.Left && this.IsDrawing) {

            this.BotPoint = this.SnapToGrid ? this.GetNearestGridPoint(new Point(e.X, e.Y)) : new Point(e.X, e.Y);
            // this.BotPoint = new Point(e.X, e.Y);

            var wrapper = (IDrawable?)Activator.CreateInstance(WrapperTypes[this.FigureType]);

            if (wrapper is not null) {
                wrapper.PenSize = this.PenSize;
                wrapper.PenColor = this.PenColor;
                wrapper.BrushColor = this.BrushColor;
                wrapper.TopPoint = this.TopPoint;
                wrapper.BotPoint = this.BotPoint;
                wrapper.IsFilling = this.IsFilling;
                wrapper.FigureType = this.FigureType;

                if (wrapper is StraightLineWrapper straightLineWrapper) {
                    straightLineWrapper.StartPoint = new Point(this.TopPoint.X, this.TopPoint.Y);
                    straightLineWrapper.EndPoint = new Point(this.BotPoint.X, this.BotPoint.Y);
                }

                if (wrapper is CurveLineWrapper curveLineWrapper) {
                    this.Points.Add(this.BotPoint);
                    curveLineWrapper.Points = new List<Point>(this.Points);
                    this.Points.Clear();
                }

                if (wrapper is TextBoxWrapper textBoxWrapper) {
                    textBoxWrapper.Text = this.Text;
                    textBoxWrapper.TextFont = this.TextFont;

                    var textBox = new TextBox() {
                        Parent = this.ParentReference,
                        Font = this.TextFont,
                        Multiline = true,
                        ForeColor = this.PenColor,
                        Location = this.TopPoint,
                        Width = this.BotPoint.X - this.TopPoint.X,
                        Height = this.BotPoint.Y - this.TopPoint.Y,
                        Text = this.Text,
                    };

                    textBox.KeyDown += this.OnTextBoxKeyDown;

                    this.Wrapper = textBoxWrapper;
                    this.TextBox = textBox;
                }

                if (this.BotPoint.X < this.CanvasSize.Width && this.BotPoint.Y < this.CanvasSize.Height && wrapper is not TextBoxWrapper) {
                    this.Figures.Add(wrapper);
                }
            }

            this.DashFigure = null;
            this.IsDrawing = false;
        }
    }
}
