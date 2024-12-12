using Paint.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Paint.Figures;

internal class TextBoxWrapper : Movable, IDrawable {
    public FiguresEnum FigureType { get; set; } = FiguresEnum.TextBox;

    public int PenSize { get; set; }
    public Color PenColor { get; set; }
    public Color BrushColor { get; set; }
    public bool IsFilling { get; set; }

    public Dictionary<ResizePointsEnum, Point> ResizePointsDict { get; set; } = [];

    public string Text { get; set; } = "";
    public Font TextFont { get; set; } = new Font("Times New Roman", 12.0f);

    public static EllipseWrapper GetCircleFromCenter(Point point, int radius) {
        var wrapper = new EllipseWrapper() {
            PenSize = 2,
            IsFilling = true,
            PenColor = Color.Black,
            BrushColor = Color.Black,
            FigureType = FiguresEnum.Ellipse,
            TopPoint = new Point(point.X - radius, point.Y - radius),
            BotPoint = new Point(point.X + radius, point.Y + radius),
        };

        return wrapper;
    }

    public Dictionary<ResizePointsEnum, EllipseWrapper> GetResizeCircles() {
        var circles = new Dictionary<ResizePointsEnum, EllipseWrapper>();

        foreach (var (key, value) in this.ResizePointsDict) {
            circles[key] = GetCircleFromCenter(value, 5);
        }

        return circles;
    }

    public void Draw(Graphics graphics) {
        var pen = new Pen(this.PenColor, this.PenSize);

        this.ValidateEdgePoint();

        var rectangle = Rectangle.FromLTRB(
            this.TopPoint.X, this.TopPoint.Y, this.BotPoint.X, this.BotPoint.Y
        );

        Brush brush = new SolidBrush(this.PenColor);
        graphics.DrawRectangle(pen, rectangle);
        graphics.DrawString(this.Text, this.TextFont, brush, rectangle);
    }

    public void DrawDash(Graphics graphics) {
        var pen = new Pen(Color.Black, this.PenSize) {
            DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
        };

        this.ValidateEdgePoint();

        var rectangle = Rectangle.FromLTRB(
            this.TopPoint.X, this.TopPoint.Y, this.BotPoint.X, this.BotPoint.Y
        );

        Brush brush = new SolidBrush(this.PenColor);
        graphics.DrawRectangle(pen, rectangle);
        graphics.DrawString(this.Text, this.TextFont, brush, rectangle);
    }

    public void DrawSelection(Graphics graphics) {
        var pen = new Pen(Color.Blue, this.PenSize) {
            DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
        };

        this.ValidateEdgePoint();

        var rectangle = Rectangle.FromLTRB(
            this.TopPoint.X, this.TopPoint.Y, this.BotPoint.X, this.BotPoint.Y
        );

        Brush brush = new SolidBrush(this.PenColor);
        graphics.DrawRectangle(pen, rectangle);
        graphics.DrawString(this.Text, this.TextFont, brush, rectangle);
    }

    public bool ContainsPoint(Point point) {
        this.ValidateEdgePoint();

        var rectangle = Rectangle.FromLTRB(
            this.TopPoint.X, this.TopPoint.Y, this.BotPoint.X, this.BotPoint.Y
        );

        return rectangle.Contains(point);
    }

    public void DrawResizing(Graphics graphics) {
        this.ValidateEdgePoint();

        var resizePoints = GetResizeCircles();
        foreach (var (_, value) in resizePoints) {
            value.Draw(graphics);
        }
    }
}
