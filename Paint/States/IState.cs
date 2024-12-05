namespace Paint.States;

public interface ICanvasSizeDepended {
    public Size CanvasSize { get; set; }
}

public interface IState {
    public void MouseUpHandler(object sender, MouseEventArgs e);

    public void MouseMoveHandler(object sender, MouseEventArgs e);

    public void MouseDownHandler(object sender, MouseEventArgs e);
}
