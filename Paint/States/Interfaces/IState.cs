namespace Paint.States.Interfaces;

internal interface IState {
    public void MouseDown();
    public void MouseMove();
    public void MouseUp();
}
