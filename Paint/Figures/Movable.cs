using Paint.Interfaces;

namespace Paint.Figures;

internal class Movable : IMovable {
    public Point TopPoint { get; set; }
    public Point BotPoint { get; set; }

    public void ValidateTopPoint() {
        var topPoint = new Point(
            Math.Min(this.TopPoint.X, this.BotPoint.X), Math.Min(this.TopPoint.Y, this.BotPoint.Y)
        );

        var botPoint = new Point(
            Math.Max(this.TopPoint.X, this.BotPoint.X), Math.Max(this.TopPoint.Y, this.BotPoint.Y)
        );

        this.TopPoint = topPoint;
        this.BotPoint = botPoint;
    }

    public bool CanMove(int dx, int dy, Size canvasSize) {
        return
            this.TopPoint.X + dx >= 0 && this.BotPoint.X + dx <= canvasSize.Width &&
            this.TopPoint.Y + dy >= 0 && this.BotPoint.Y + dy <= canvasSize.Height
        ;
    }

    public void Move(int dx, int dy) {
        this.TopPoint = new Point(this.TopPoint.X + dx, this.TopPoint.Y + dy);
        this.BotPoint = new Point(this.BotPoint.X + dx, this.BotPoint.Y + dy);
    }
}
