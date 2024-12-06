namespace Paint.Figures;

internal interface ITopBottomPoints {
    public Point TopPoint { get; set; }
    public Point BottomPoint { get; set; }
}

internal interface IMovable : ITopBottomPoints {
    public bool CanMove(int dx, int dy, Size canvasSize);

    public void Move(int dx, int dy);
}

internal class Movable : IMovable {
    public Point TopPoint { get; set; }
    public Point BottomPoint { get; set; }

    public bool CanMove(int dx, int dy, Size canvasSize) {
        return
            this.TopPoint.X + dx >= 0 && this.BottomPoint.X + dx <= canvasSize.Width &&
            this.TopPoint.Y + dy >= 0 && this.BottomPoint.Y + dy <= canvasSize.Height
        ;
    }

    public void Move(int dx, int dy) {
        this.TopPoint = new Point(this.TopPoint.X + dx, this.TopPoint.Y + dy);
        this.BottomPoint = new Point(this.BottomPoint.X + dx, this.BottomPoint.Y + dy);
    }
}
