using Paint.Figures;

namespace Paint.States;

public class SelectState : IState, ISelection {
    public IFigure? SelectedFigure { get; set; } = null;
    public List<IFigure> Figures { get; set; } = [];
    public List<IFigure> SelectedFigures { get; set; } = [];

    public bool IsMoving { get; set; } = false;
    public Size CanvasSize { get; set; } = new Size(800, 600);
    public Point DragStartPoint { get; set; } = new Point(0, 0);

    public void MouseDownHandler(object sender, MouseEventArgs e) {
        this.DragStartPoint = new Point(e.X, e.Y);

        if (e.Button == MouseButtons.Left) {
            var point = new Point(e.X, e.Y);
            bool isPointUsed;
            foreach (IFigure figure in this.Figures) {
                isPointUsed = false;
                if (figure.ContainsPoint(point) && !isPointUsed) {
                    if (this.SelectedFigures.Contains(figure)) {
                        _ = this.SelectedFigures.Remove(figure);
                    } else {
                        this.SelectedFigures.Add(figure);
                    }

                    isPointUsed = true;
                }

                if (isPointUsed) {
                    break;
                }
            }

            if (this.SelectedFigures.Count == 1 && !this.IsMoving) {
                this.IsMoving = true;
            }
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
        if (this.SelectedFigure is not null && this.IsMoving) {
            this.IsMoving = false;
        }
    }
}
