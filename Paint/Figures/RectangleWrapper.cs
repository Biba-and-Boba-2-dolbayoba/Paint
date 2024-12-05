namespace Paint.Figures;

public class RectangleWrapper : Movable, IFigure {
    public int PenSize { get; set; }
    public Color PenColor { get; set; }
    public Color BrushColor { get; set; }
    public bool IsFilling { get; set; }

    public void Draw(Graphics graphics) {
        var pen = new Pen(this.PenColor, this.PenSize);

        var rectangle = Rectangle.FromLTRB(
            Math.Min(this.StartPoint.X, this.EndPoint.X),
            Math.Min(this.StartPoint.Y, this.EndPoint.Y),
            Math.Max(this.StartPoint.X, this.EndPoint.X),
            Math.Max(this.StartPoint.Y, this.EndPoint.Y)
        );

        if (this.IsFilling) {
            Brush brush = new SolidBrush(this.BrushColor);
            graphics.FillRectangle(brush, rectangle);
        }

        graphics.DrawRectangle(pen, rectangle);
    }

    public void Hide(Graphics graphics) {
        var pen = new Pen(Color.White, this.PenSize);

        var rectangle = Rectangle.FromLTRB(
            Math.Min(this.StartPoint.X, this.EndPoint.X),
            Math.Min(this.StartPoint.Y, this.EndPoint.Y),
            Math.Max(this.StartPoint.X, this.EndPoint.X),
            Math.Max(this.StartPoint.Y, this.EndPoint.Y)
        );

        graphics.DrawRectangle(pen, rectangle);
    }

    public void DrawDash(Graphics graphics) {
        var pen = new Pen(Color.Black, this.PenSize) {
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
        var rectangle = Rectangle.FromLTRB(
            Math.Min(this.StartPoint.X, this.EndPoint.X),
            Math.Min(this.StartPoint.Y, this.EndPoint.Y),
            Math.Max(this.StartPoint.X, this.EndPoint.X),
            Math.Max(this.StartPoint.Y, this.EndPoint.Y)
        );

        return rectangle.Contains(point);
    }
}
