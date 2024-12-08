using Paint.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Paint.Figures;

internal class CurveLineWrapper : Movable, IDrawable, IPointsDependence, IToleranceDependence {
    public FiguresEnum FigureType { get; set; } = FiguresEnum.CurveLine;

    public int PenSize { get; set; }
    public Color PenColor { get; set; }
    public Color BrushColor { get; set; }
    public bool IsFilling { get; set; }

    public List<Point> Points { get; set; } = [];

    public int Tolerance { get; set; } = 10;

    public override void ValidateEdgePoint() {
        foreach (Point point in this.Points) {
            if (point.X < this.TopPoint.X) {
                this.TopPoint = new Point(point.X, this.TopPoint.Y);
            }

            if (point.Y < this.TopPoint.Y) {
                this.TopPoint = new Point(this.TopPoint.X, point.Y);
            }

            if (point.X > this.BotPoint.X) {
                this.BotPoint = new Point(point.X, this.BotPoint.Y);
            }

            if (point.Y > this.BotPoint.Y) {
                this.BotPoint = new Point(this.BotPoint.X, point.Y);
            }
        }
    }

    public override void Move(int dx, int dy) {
        base.Move(dx, dy);

        List<Point> points = [];

        foreach (Point point in this.Points) {
            points.Add(new Point(point.X + dx, point.Y + dy));
        }

        this.Points = new List<Point>(points);
    }

    public void Draw(Graphics graphics) {
        var pen = new Pen(this.PenColor, this.PenSize);

        this.ValidateEdgePoint();

        if (this.Points.Count >= 3) {
            graphics.DrawCurve(pen, this.Points.ToArray());
        }
    }

    public void DrawDash(Graphics graphics) {
        var pen = new Pen(Color.Black, this.PenSize) {
            DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
        };

        this.ValidateEdgePoint();

        if (this.Points.Count >= 3) {
            graphics.DrawCurve(pen, this.Points.ToArray());
        }
    }

    public void DrawSelection(Graphics graphics) {
        var bluePen = new Pen(Color.Blue, this.PenSize) {
            DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
        };

        var blackPen = new Pen(Color.Black, this.PenSize) {
            DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
        };

        this.ValidateEdgePoint();

        var rectangle = Rectangle.FromLTRB(
            this.TopPoint.X, this.TopPoint.Y, this.BotPoint.X, this.BotPoint.Y
        );

        graphics.DrawRectangle(blackPen, rectangle);

        if (this.Points.Count >= 3) {
            graphics.DrawCurve(bluePen, this.Points.ToArray());
        }
    }

    public bool ContainsPoint(Point point) {
        foreach (Point _point in this.Points) {
            double distance = Math.Sqrt(
                Math.Pow(_point.X - point.X, 2) + Math.Pow(_point.Y - point.Y, 2)
            );

            if (distance <= this.Tolerance) {
                return true;
            }
        }

        return false;
    }
}
