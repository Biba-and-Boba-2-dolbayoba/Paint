namespace Paint.Interfaces;

internal interface IState : IFiguresDependence {
    public void MouseUpHandler(object sender, MouseEventArgs e);
    public void MouseMoveHandler(object sender, MouseEventArgs e);
    public void MouseDownHandler(object sender, MouseEventArgs e);
}
