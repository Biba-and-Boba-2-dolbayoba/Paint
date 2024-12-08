using Paint.Interfaces;

namespace Paint.Figures;

internal class StraightLineWrapper : Movable, IDrawable, IStartEndDependence, IToleranceDependence {
    public FiguresEnum FigureType { get; set; } = FiguresEnum.StraightLine;

    public int PenSize { get; set; }
    public Color PenColor { get; set; }
    public Color BrushColor { get; set; }
    public bool IsFilling { get; set; }

    public Point StartPoint { get; set; }
    public Point EndPoint { get; set; }

    public int Tolerance { get; set; } = 10;

    public override void Move(int dx, int dy) {
        base.Move(dx, dy);

        this.StartPoint = new Point(this.StartPoint.X + dx, this.StartPoint.Y + dy);
        this.EndPoint = new Point(this.EndPoint.X + dx, this.EndPoint.Y + dy);
    }

    public void Draw(Graphics graphics) {
        this.ValidateEdgePoint();

        var pen = new Pen(this.PenColor, this.PenSize);
        graphics.DrawLine(pen, this.StartPoint, this.EndPoint);
    }

    public void DrawDash(Graphics graphics) {
        var pen = new Pen(Color.Black, this.PenSize) {
            DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
        };

        this.ValidateEdgePoint();

        graphics.DrawLine(pen, this.StartPoint, this.EndPoint);
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
        graphics.DrawLine(bluePen, this.StartPoint, this.EndPoint);
    }

    public bool ContainsPoint(Point point) {
        int coefficientA = this.EndPoint.Y - this.StartPoint.Y;
        int coefficientB = -(this.EndPoint.X - this.StartPoint.X);
        int coefficientC = (this.EndPoint.X * this.StartPoint.Y) - (this.EndPoint.Y * this.StartPoint.X);

        int numerator = Math.Abs((coefficientA * point.X) + (coefficientB * point.Y) + coefficientC);

        double denominator = Math.Sqrt(Math.Pow(this.EndPoint.Y - this.StartPoint.Y, 2) + Math.Pow(this.EndPoint.X - this.StartPoint.X, 2));

        double distance = numerator / denominator;

        return distance <= this.Tolerance;
    }
}
