using Paint.Interfaces;

namespace Paint.Figures;

internal class CurveLineWrapper : Movable, IDrawable, IPointsDependence {
    public FiguresEnum FigureType { get; set; } = FiguresEnum.CurveLine;

    public int PenSize { get; set; }
    public Color PenColor { get; set; }
    public Color BrushColor { get; set; }
    public bool IsFilling { get; set; }

    public List<Point> Points { get; set; } = [];

    public void Draw(Graphics graphics) {
        var pen = new Pen(this.PenColor, this.PenSize);

        if (this.Points.Count >= 3) {
            graphics.DrawCurve(pen, this.Points.ToArray());
        }
    }

    public void Hide(Graphics graphics) {
        var pen = new Pen(Color.White, this.PenSize);

        if (this.Points.Count >= 3) {
            graphics.DrawCurve(pen, this.Points.ToArray());
        }
    }

    public void DrawDash(Graphics graphics) {
        var pen = new Pen(Color.Black, this.PenSize) {
            DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
        };

        if (this.Points.Count >= 3) {
            graphics.DrawCurve(pen, this.Points.ToArray());
        }
    }

    public void DrawSelection(Graphics graphics) {
        var pen = new Pen(Color.Blue, this.PenSize) {
            DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
        };

        var rectangle = Rectangle.FromLTRB(
            Math.Min(this.TopPoint.X, this.BotPoint.X),
            Math.Min(this.TopPoint.Y, this.BotPoint.Y),
            Math.Max(this.TopPoint.X, this.BotPoint.X),
            Math.Max(this.TopPoint.Y, this.BotPoint.Y)
        );

        graphics.DrawRectangle(pen, rectangle);
    }

    public bool ContainsPoint(Point point) {
        const int tolerance = 3;

        for (int i = 0 ; i < this.Points.Count - 1 ; i++) {
            Point start = this.Points.ElementAt(i);
            Point end = this.Points.ElementAt(i + 1);

            int abs = Math.Abs(
                ((end.Y - start.Y) * point.X) - ((end.X - start.X) * point.Y) + (end.X * start.Y) - (end.Y * start.X)
            );

            double sqrt = Math.Sqrt(
                Math.Pow(end.Y - start.Y, 2) + Math.Pow(end.X - this.TopPoint.X, 2)
            );

            double distance = abs / sqrt;

            if (distance <= tolerance) {
                return true;
            }
        }

        return false;
    }
}
