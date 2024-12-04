namespace Paint.Figures;

public interface IMovable : IStartEndPoint {
    public bool CanMove(int dx, int dy, Size canvasSize);

    public void Move(int dx, int dy);
}

public class Movable : IMovable {
    public Point StartPoint { get; set; }
    public Point EndPoint { get; set; }

    public bool CanMove(int dx, int dy, Size canvasSize) {
        return
            this.StartPoint.X + dx >= 0 && this.EndPoint.X + dx <= canvasSize.Width &&
            this.StartPoint.Y + dy >= 0 && this.EndPoint.Y + dy <= canvasSize.Height
        ;
    }

    public void Move(int dx, int dy) {
        this.StartPoint = new Point(this.StartPoint.X + dx, this.StartPoint.Y + dy);
        this.EndPoint = new Point(this.EndPoint.X + dx, this.EndPoint.Y + dy);
    }
}
