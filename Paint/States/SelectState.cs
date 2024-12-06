using Paint.Figures;

namespace Paint.States;

internal class SelectState : IState, ISelection {
    public List<IFigure> Figures { get; set; } = [];
    public List<IFigure> SelectedFigures { get; set; } = [];

    public bool IsMoving { get; set; } = false;
    public Size CanvasSize { get; set; } = new Size(800, 600);
    public Point DragStartPoint { get; set; } = new Point(0, 0);

    public void MouseDownHandler(object sender, MouseEventArgs e) {
        this.DragStartPoint = new Point(e.X, e.Y);

        if (e.Button == MouseButtons.Left) {
            var point = new Point(e.X, e.Y);
            bool isClickOnFigure = false;
            foreach (IFigure figure in this.Figures) {
                if (figure.ContainsPoint(point)) {
                    isClickOnFigure = true;
                    if (this.SelectedFigures.Contains(figure)) {
                        _ = this.SelectedFigures.Remove(figure);
                        continue;
                    } else {
                        this.SelectedFigures.Add(figure);
                        continue;
                    }
                }
            }

            if (!isClickOnFigure) {
                foreach (IFigure figure in this.SelectedFigures) {
                    this.Figures.Add(figure);
                }

                this.SelectedFigures.Clear();
            }

            this.IsMoving = true;
        }
    }

    public void MouseMoveHandler(object sender, MouseEventArgs e) {
        if (this.SelectedFigures.Count == 1 && this.IsMoving) {
            int dx = e.X - this.DragStartPoint.X;
            int dy = e.Y - this.DragStartPoint.Y;

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
