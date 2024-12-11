using Paint.Interfaces;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Paint.States;

internal class EditState : IState {
    public List<IDrawable> Figures { get; set; } = [];
    public IDrawable? SelectedFigure { get; set; }

    public bool IsMoving { get; set; } = false;
    public Size CanvasSize { get; set; }
    public Point DragStartPoint { get; set; } = new Point(0, 0);

    public void MouseDownHandler(MouseEventArgs e) {
        this.DragStartPoint = new Point(e.X, e.Y);
        var point = new Point(e.X, e.Y);
        if (e.Button == MouseButtons.Left) {
            bool isContains = false;
            foreach (IDrawable figure in this.Figures) {
                if (figure.ContainsPoint(point)) {
                    isContains = true;
                    if (SelectedFigure is null) {
                        this.SelectedFigure = null;
                        break;
                    }
                }
            }

            if (!isContains) {
                this.SelectedFigure = null;
            }

            this.IsMoving = true;
        }

        if (e.Button == MouseButtons.Right) {
            foreach (IDrawable figure in this.Figures) {
                if (figure.ContainsPoint(point) && this.SelectedFigure == figure) {
                    this.SelectedFigure = null;
                    break;
                }
            }
        }
    }

    public void MouseMoveHandler(MouseEventArgs e) {
        if (SelectedFigure is null) return;

        if (this.IsMoving) {
            int dx = e.X - this.DragStartPoint.X;
            int dy = e.Y - this.DragStartPoint.Y;

            SelectedFigure.ValidateEdgePoint();
            if (SelectedFigure.CanMove(dx, dy, this.CanvasSize)) {
                return;
            }
            SelectedFigure.Move(dx, dy);
            this.DragStartPoint = new Point(e.X, e.Y);
        }
    }

    public void MouseUpHandler(MouseEventArgs e) {
        this.IsMoving = false;
    }
}
