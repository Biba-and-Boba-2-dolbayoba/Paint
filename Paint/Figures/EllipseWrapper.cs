using Paint.Interfaces;

namespace Paint.Figures;

internal class EllipseWrapper : Movable, IDrawable {
    public FiguresEnum FigureType { get; set; } = FiguresEnum.Ellipse;

    public int PenSize { get; set; }
    public Color PenColor { get; set; }
    public Color BrushColor { get; set; }
    public bool IsFilling { get; set; }

    public void Draw(Graphics graphics) {
        var pen = new Pen(this.PenColor, this.PenSize);

        this.ValidateTopPoint();

        var rectangle = Rectangle.FromLTRB(
            this.TopPoint.X, this.TopPoint.Y, this.BotPoint.X, this.BotPoint.Y
        );

        if (this.IsFilling) {
            Brush brush = new SolidBrush(this.BrushColor);
            graphics.FillEllipse(brush, rectangle);
        }

        graphics.DrawEllipse(pen, rectangle);
    }

    public void Hide(Graphics graphics) {
        var pen = new Pen(Color.White, this.PenSize);

        this.ValidateTopPoint();

        var rectangle = Rectangle.FromLTRB(
            this.TopPoint.X, this.TopPoint.Y, this.BotPoint.X, this.BotPoint.Y
        );

        graphics.DrawEllipse(pen, rectangle);
    }

    public void DrawDash(Graphics graphics) {
        var pen = new Pen(Color.Black, this.PenSize) {
            DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
        };

        this.ValidateTopPoint();

        var rectangle = Rectangle.FromLTRB(
            this.TopPoint.X, this.TopPoint.Y, this.BotPoint.X, this.BotPoint.Y
        );

        graphics.DrawEllipse(pen, rectangle);
    }

    public void DrawSelection(Graphics graphics) {
        var bluePen = new Pen(Color.Blue, this.PenSize) {
            DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
        };

        var blackPen = new Pen(Color.Black, this.PenSize) {
            DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
        };

        this.ValidateTopPoint();

        var rectangle = Rectangle.FromLTRB(
            this.TopPoint.X, this.TopPoint.Y, this.BotPoint.X, this.BotPoint.Y
        ); ;

        graphics.DrawRectangle(blackPen, rectangle);
        graphics.DrawEllipse(bluePen, rectangle);
    }

    public bool ContainsPoint(Point point) {
        this.ValidateTopPoint();

        var rectangle = Rectangle.FromLTRB(
            this.TopPoint.X, this.TopPoint.Y, this.BotPoint.X, this.BotPoint.Y
        );

        double radiusX = rectangle.Width / 2.0;
        double radiusY = rectangle.Height / 2.0;

        double centerX = rectangle.Left + radiusX;
        double centerY = rectangle.Top + radiusY;

        double normalizedX = (point.X - centerX) / radiusX;
        double normalizedY = (point.Y - centerY) / radiusY;

        return (normalizedX * normalizedX) + (normalizedY * normalizedY) <= 1;
    }
}
