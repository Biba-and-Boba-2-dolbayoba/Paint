namespace Serializer.Interfaces;
using System.Drawing;

internal interface IMovable : ITopBottomDepends {
    public bool CanMove(int dx, int dy, Size canvasSize);
    public void Move(int dx, int dy);
}
