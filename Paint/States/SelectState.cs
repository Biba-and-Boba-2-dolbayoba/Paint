using Paint.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Paint.States;

internal class SelectState : IState, ISelection {
    public List<IDrawable> Figures { get; set; } = [];
    public List<IDrawable> SelectedFigures { get; set; } = [];

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
                    if (!this.SelectedFigures.Contains(figure)) {
                        this.SelectedFigures.Add(figure);
                        break;
                    }
                }
            }

            if (!isContains) {
                this.SelectedFigures.Clear();
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
        if (this.IsMoving) {
            int dx = e.X - this.DragStartPoint.X;
            int dy = e.Y - this.DragStartPoint.Y;

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
        this.IsMoving = false;
    }
}
