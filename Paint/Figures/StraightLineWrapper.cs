using Paint.Interfaces;

namespace Paint.Figures;

internal class StraightLineWrapper : Movable, IDrawable {
    public FiguresEnum FigureType { get; set; } = FiguresEnum.StraightLine;

    public int PenSize { get; set; }
    public Color PenColor { get; set; }
    public Color BrushColor { get; set; }
    public bool IsFilling { get; set; }

    public void Draw(Graphics graphics) {
        var pen = new Pen(this.PenColor, this.PenSize);
        graphics.DrawLine(pen, this.TopPoint, this.BotPoint);
    }

    public void Hide(Graphics graphics) {
        var pen = new Pen(Color.White, this.PenSize);
        graphics.DrawLine(pen, this.TopPoint, this.BotPoint);
    }

    public void DrawDash(Graphics graphics) {
        var pen = new Pen(Color.Black, this.PenSize) {
            DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
        };

        graphics.DrawLine(pen, this.TopPoint, this.BotPoint);
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

        int abs = Math.Abs(
            ((this.BotPoint.Y - this.TopPoint.Y) * point.X) -
            ((this.BotPoint.X - this.TopPoint.X) * point.Y) +
            (this.BotPoint.X * this.TopPoint.Y) -
            (this.BotPoint.Y * this.TopPoint.X)
        );

        double sqrt = Math.Sqrt(
            Math.Pow(this.BotPoint.Y - this.TopPoint.Y, 2) + Math.Pow(this.BotPoint.X - this.TopPoint.X, 2)
        );

        double distance = abs / sqrt;

        return distance <= tolerance;
    }
}
