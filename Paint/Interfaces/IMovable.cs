using System.Drawing;

namespace Paint.Interfaces;
internal interface IMovable : ITopBottomPoints {
    public void ValidateEdgePoint();
    public bool CanMove(int dx, int dy, Size canvasSize);
    public void Move(int dx, int dy);
}
