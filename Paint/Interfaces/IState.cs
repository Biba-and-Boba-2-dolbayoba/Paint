namespace Paint.Interfaces;

internal enum StatesEnum {
    DrawState,
    SelectState,
    EditState

}

internal interface IState : IFiguresDependence, ICanvasSizeDependence {
    public void MouseUpHandler(MouseEventArgs e);
    public void MouseMoveHandler(MouseEventArgs e);
    public void MouseDownHandler(MouseEventArgs e);
}
