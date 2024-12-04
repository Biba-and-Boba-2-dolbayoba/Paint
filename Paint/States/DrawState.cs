using Paint.Figures;

namespace Paint.States;

public class DrawState : IState, IDrawing {
    public bool IsDrawing { get; set; } = false;

    public Point StartPoint { get; set; }
    public Point EndPoint { get; set; }
    public List<Point> Points { get; set; } = [];

    public FiguresEnum FigureType { get; set; } = FiguresEnum.Rectangle;

    public void MouseDownHandler(object sender, MouseEventArgs e) {
        if (e.Button == MouseButtons.Left && !this.IsDrawing) {
            this.Points.Clear();

            this.StartPoint = new Point(e.X, e.Y);
            this.EndPoint = new Point(e.X, e.Y);

            this.Points.Add(this.StartPoint);
            this.Points.Add(this.EndPoint);

            this.IsDrawing = true;
        }
    }

    public void MouseMoveHandler(object sender, MouseEventArgs e) {
        if (this.FigureType == FiguresEnum.Rectangle) {
            this.EndPoint = new Point(e.X, e.Y);
            _ = new Rect(this.StartPoint, this.EndPoint, Color.Black, Color.White, 1, parent.IsFilling, no_curve, no_font, no_text);
        }

        if (this.FigureType == FiguresEnum.Ellipse) {

        }

        if (this.FigureType == FiguresEnum.Line) {

        }

        if (this.FigureType == FiguresEnum.CurveLine) {

        }

        if (this.FigureType == FiguresEnum.TextBox) {

        }
    }

    public void MouseUpHandler(object sender, MouseEventArgs e) {
        throw new NotImplementedException();
    }
}
