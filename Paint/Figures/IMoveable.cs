namespace Paint.Figures;
internal interface IMoveable {
    public bool CanMove(int dx, int dy, Size bounds);
    public void Move(int dx, int dy);


}
