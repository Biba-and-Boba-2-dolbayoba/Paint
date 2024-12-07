namespace Paint.Interfaces;

internal interface IMovable : ITopBottomDependence {
    public void ValidateTopPoint();
    public bool CanMove(int dx, int dy, Size canvasSize);
    public void Move(int dx, int dy);
}
