using Paint.Interfaces;
using System;
using System.Drawing;

namespace Paint.Figures;

internal class Movable : IMovable {
    public Point TopPoint { get; set; }
    public Point BotPoint { get; set; }

    public virtual void ValidateEdgePoint() {
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
        bool canTopPoint = this.TopPoint.X + dx > 0 && this.TopPoint.Y + dy > 0;
        bool canBotPoint = this.BotPoint.X + dx < canvasSize.Width && this.BotPoint.Y + dy < canvasSize.Height;

        return canTopPoint && canBotPoint;
    }

    public virtual void Move(int dx, int dy) {
        this.TopPoint = new Point(this.TopPoint.X + dx, this.TopPoint.Y + dy);
        this.BotPoint = new Point(this.BotPoint.X + dx, this.BotPoint.Y + dy);
    }
}
