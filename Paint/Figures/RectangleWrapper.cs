﻿using Paint.Interfaces;
using System.Collections.Generic;
using System.Drawing;

namespace Paint.Figures;

internal class RectangleWrapper : Movable, IDrawable {
    public FiguresEnum FigureType { get; set; } = FiguresEnum.Rectangle;

    public int PenSize { get; set; }
    public Color PenColor { get; set; }
    public Color BrushColor { get; set; }
    public bool IsFilling { get; set; }

    public Dictionary<ResizePointsEnum, Point> ResizePointsDict { get; set; } = [];

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

    public void UpdateResizePointsDict() {
        var topLeftPoint = this.TopPoint;
        var botRightPoint = this.BotPoint;
        var topRightPoint = new Point(botRightPoint.X, topLeftPoint.Y);
        var botLeftPoint = new Point(topLeftPoint.X, botRightPoint.Y);

        var middleX = topLeftPoint.X + (topRightPoint.X - topLeftPoint.X) / 2;
        var middleY = topLeftPoint.Y + (botLeftPoint.Y - topLeftPoint.Y) / 2;

        var middleLeftPoint = new Point(topLeftPoint.X, middleY);
        var middleTopPoint = new Point(middleX, topLeftPoint.Y);
        var middleRightPoint = new Point(botRightPoint.X, middleY);
        var middleBotPoint = new Point(middleX, botRightPoint.Y);

        this.ResizePointsDict[ResizePointsEnum.TopLeft] = topLeftPoint;
        this.ResizePointsDict[ResizePointsEnum.BotRight] = botRightPoint;
        this.ResizePointsDict[ResizePointsEnum.TopRight] = topRightPoint;
        this.ResizePointsDict[ResizePointsEnum.BotLeft] = botLeftPoint;
        this.ResizePointsDict[ResizePointsEnum.MiddleLeft] = middleLeftPoint;
        this.ResizePointsDict[ResizePointsEnum.MiddleTop] = middleTopPoint;
        this.ResizePointsDict[ResizePointsEnum.MiddleRight] = middleRightPoint;
        this.ResizePointsDict[ResizePointsEnum.MiddleBot] = middleBotPoint;
    }

    public override void Move(int dx, int dy) {
        base.Move(dx, dy);
    }

    public void Draw(Graphics graphics) {
        var pen = new Pen(this.PenColor, this.PenSize);

        this.ValidateEdgePoint();

        var rectangle = Rectangle.FromLTRB(
            this.TopPoint.X, this.TopPoint.Y, this.BotPoint.X, this.BotPoint.Y
        );

        if (this.IsFilling) {
            Brush brush = new SolidBrush(this.BrushColor);
            graphics.FillRectangle(brush, rectangle);
        }

        graphics.DrawRectangle(pen, rectangle);
    }

    public void DrawDash(Graphics graphics) {
        var pen = new Pen(Color.Black, this.PenSize) {
            DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
        };

        this.ValidateEdgePoint();

        var rectangle = Rectangle.FromLTRB(
            this.TopPoint.X, this.TopPoint.Y, this.BotPoint.X, this.BotPoint.Y
        );

        graphics.DrawRectangle(pen, rectangle);
    }

    public void DrawSelection(Graphics graphics) {
        var pen = new Pen(Color.Blue, this.PenSize) {
            DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
        };

        this.ValidateEdgePoint();

        var rectangle = Rectangle.FromLTRB(
            this.TopPoint.X, this.TopPoint.Y, this.BotPoint.X, this.BotPoint.Y
        );

        graphics.DrawRectangle(pen, rectangle);
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
