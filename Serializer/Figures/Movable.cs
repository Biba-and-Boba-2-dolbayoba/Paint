using Serializer.Interfaces;
using System.Drawing;

namespace Serializer.Figures;

internal class Movable : IMovable {
    public Point TopPoint { get; set; }
    public Point BotPoint { get; set; }

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
