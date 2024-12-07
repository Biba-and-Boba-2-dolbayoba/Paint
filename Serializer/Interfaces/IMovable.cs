using System.Drawing;

namespace Serializer.Interfaces;
internal interface IMovable : ITopBottomDepends {
    public bool CanMove(int dx, int dy, Size canvasSize);
    public void Move(int dx, int dy);
}
