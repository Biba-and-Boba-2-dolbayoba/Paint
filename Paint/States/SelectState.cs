using Paint.Figures;

namespace Paint.States;

public class SelectState : IState, ISelection {
    public Figure? SelectedFigure { get; set; } = null;
    public List<Figure> Figures { get; set; } = [];
    public List<Figure> SelectedFigures { get; set; } = [];

    public bool IsMoving { get; set; } = false;
    public Size CanvasSize { get; set; } = new Size(800, 600);
    public Point DragStartPoint { get; set; } = new Point(0, 0);

    public void MouseDownHandler(object sender, MouseEventArgs e) {
        this.DragStartPoint = new Point(e.X, e.Y);

        if (e.Button == MouseButtons.Left) {
            this.SelectedFigures.Clear();

            if (this.SelectedFigure is not null && !this.IsMoving) {
                this.IsMoving = true;
                return;
            }

            foreach (Figure figure in this.Figures) {
                if (figure.ContainsPoint(new Point(e.X, e.Y))) {
                    this.SelectedFigure = figure == this.SelectedFigure ? null : figure;
                    return;
                }
            }
        }

        if (e.Button == MouseButtons.Right) {
            this.SelectedFigure = null;
            foreach (Figure figure in this.Figures) {
                if (figure.ContainsPoint(new Point(e.X, e.Y))) {
                    this.SelectedFigures.Add(figure);
                }
            }
        }
    }

    public void MouseMoveHandler(object sender, MouseEventArgs e) {
        if (this.SelectedFigure is not null && this.IsMoving) {
            int dx = e.X - this.DragStartPoint.X;
            int dy = e.Y - this.DragStartPoint.Y;

            if (this.SelectedFigure.CanMove(dx, dy, this.CanvasSize)) {
                this.SelectedFigure.Move(dx, dy);
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
