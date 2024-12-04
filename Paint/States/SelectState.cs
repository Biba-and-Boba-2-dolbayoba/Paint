using Paint.Figures;

namespace Paint.States;

public class SelectState(List<Figure> figures) : IState, ISelectable {
    public Figure? SelectedFigure { get; set; }
    public List<Figure> Figures { get; set; } = figures;
    public List<Figure> SelectedFigures { get; set; } = [];

    public void MouseDownHandler(object sender, MouseEventArgs e) {
        if (e.Button == MouseButtons.Left) {
            foreach (Figure figure in Figures) {
                if (figure.ContainsPoint(new Point(e.X, e.Y))) {
                    SelectedFigure = figure;
                    return;
                }
            }
        }

        if (e.Button == MouseButtons.Right) {
            foreach (Figure figure in Figures) {
                if (figure.ContainsPoint(new Point(e.X, e.Y))) {
                    SelectedFigures.Add(figure);
                }
            }
        }
    }

    public void MouseMoveHandler(object sender, MouseEventArgs e) {
        if (this.SelectedFigures.Count > 0) {
            int dx = e.X - this.DragStartPoint.X;
            int dy = e.Y - this.DragStartPoint.Y;

            if (this.SelectedFigure.CanMove(dx, dy, this.CanvasSize)) {
                this.SelectedFigure.Move(dx, dy);
                this.DragStartPoint = new Point(e.X, e.Y);
                this.Invalidate();
            }
        }
    }

    public void MouseUpHandler(object sender, MouseEventArgs e) {
        throw new NotImplementedException();
    }
}
