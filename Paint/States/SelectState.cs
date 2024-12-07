using Paint.Interfaces;

namespace Paint.States;

internal class SelectState : IState, ISelection {
    public List<IDrawable> Figures { get; set; } = [];
    public List<IDrawable> SelectedFigures { get; set; } = [];

    public bool IsMoving { get; set; } = false;
    public Size CanvasSize { get; set; } = new Size(800, 600);
    public Point DragStartPoint { get; set; } = new Point(0, 0);

    public void MouseDownHandler(object sender, MouseEventArgs e) {
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

    public void MouseMoveHandler(object sender, MouseEventArgs e) {
        if (this.SelectedFigures.Count == 1 && this.IsMoving) {
            int dx = e.X - this.DragStartPoint.X;
            int dy = e.Y - this.DragStartPoint.Y;
            if (this.SelectedFigures[0].FigureType != FiguresEnum.StraightLine) {
                this.SelectedFigures[0].ValidateTopPoint();
            }

            if (this.SelectedFigures[0].CanMove(dx, dy, this.CanvasSize)) {
                this.SelectedFigures[0].Move(dx, dy);
                this.DragStartPoint = new Point(e.X, e.Y);
            }
        }
    }

    public void MouseUpHandler(object sender, MouseEventArgs e) {
        this.IsMoving = false;
    }
}
