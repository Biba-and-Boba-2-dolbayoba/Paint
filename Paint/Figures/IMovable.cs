namespace Paint.Figures;
internal interface IMovable {
    public bool CanMove(int dx, int dy, Size bounds);
    public void Move(int dx, int dy);


}
