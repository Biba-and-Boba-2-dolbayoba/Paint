using Serializer.Interfaces;
using System.Drawing;

namespace Serializer.Figures;

internal class RectangleWrapper : Movable, IDrawable {
    public FiguresEnum FigureType { get; set; } = FiguresEnum.Rectangle;

    public int PenSize { get; set; }
    public Color PenColor { get; set; }
    public Color BrushColor { get; set; }
    public bool IsFilling { get; set; }

    public void Draw(Graphics graphics) {
        var pen = new Pen(this.PenColor, this.PenSize);

        var rectangle = Rectangle.FromLTRB(
            Math.Min(this.TopPoint.X, this.BotPoint.X),
            Math.Min(this.TopPoint.Y, this.BotPoint.Y),
            Math.Max(this.TopPoint.X, this.BotPoint.X),
            Math.Max(this.TopPoint.Y, this.BotPoint.Y)
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
            Math.Min(this.TopPoint.X, this.BotPoint.X),
            Math.Min(this.TopPoint.Y, this.BotPoint.Y),
            Math.Max(this.TopPoint.X, this.BotPoint.X),
            Math.Max(this.TopPoint.Y, this.BotPoint.Y)
        );

        graphics.DrawRectangle(pen, rectangle);
    }

    public void DrawDash(Graphics graphics) {
        var pen = new Pen(Color.Black, this.PenSize) {
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
        var rectangle = Rectangle.FromLTRB(
            Math.Min(this.TopPoint.X, this.BotPoint.X),
            Math.Min(this.TopPoint.Y, this.BotPoint.Y),
            Math.Max(this.TopPoint.X, this.BotPoint.X),
            Math.Max(this.TopPoint.Y, this.BotPoint.Y)
        );

        return rectangle.Contains(point);
    }
}
