namespace Paint.Figures;

public class StraightLineWrapper : Movable, IFigure {
    public int PenSize { get; set; }
    public Color PenColor { get; set; }
    public Color BrushColor { get; set; }
    public bool IsFilling { get; set; }

    public void Draw(Graphics graphics) {
        var pen = new Pen(this.PenColor, this.PenSize);
        graphics.DrawLine(pen, this.StartPoint, this.EndPoint);
    }

    public void Hide(Graphics graphics) {
        var pen = new Pen(Color.White, this.PenSize);
        graphics.DrawLine(pen, this.StartPoint, this.EndPoint);
    }

    public void DrawDash(Graphics graphics) {
        var pen = new Pen(Color.Black, this.PenSize) {
            DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
        };

        graphics.DrawLine(pen, this.StartPoint, this.EndPoint);
    }

    public void DrawSelection(Graphics graphics) {
        var pen = new Pen(Color.Blue, this.PenSize) {
            DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
        };

        var rectangle = Rectangle.FromLTRB(
            Math.Min(this.StartPoint.X, this.EndPoint.X),
            Math.Min(this.StartPoint.Y, this.EndPoint.Y),
            Math.Max(this.StartPoint.X, this.EndPoint.X),
            Math.Max(this.StartPoint.Y, this.EndPoint.Y)
        );

        graphics.DrawRectangle(pen, rectangle);
    }

    public bool ContainsPoint(Point point) {
        const int tolerance = 3;

        int abs = Math.Abs(
            ((this.EndPoint.Y - this.StartPoint.Y) * point.X) -
            ((this.EndPoint.X - this.StartPoint.X) * point.Y) +
            (this.EndPoint.X * this.StartPoint.Y) -
            (this.EndPoint.Y * this.StartPoint.X)
        );

        double sqrt = Math.Sqrt(
            Math.Pow(this.EndPoint.Y - this.StartPoint.Y, 2) + Math.Pow(this.EndPoint.X - this.StartPoint.X, 2)
        );

        double distance = abs / sqrt;

        return distance <= tolerance;
    }
}
