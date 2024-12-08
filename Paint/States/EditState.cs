using Paint.Interfaces;

namespace Paint.States;

internal class EditState : IState {
    public List<IDrawable> Figures { get; set; } = [];
    public Size CanvasSize { get; set; }

    public void MouseDownHandler(MouseEventArgs e) {
        throw new NotImplementedException();
    }

    public void MouseMoveHandler(MouseEventArgs e) {
        throw new NotImplementedException();
    }

    public void MouseUpHandler(MouseEventArgs e) {
        throw new NotImplementedException();
    }
}
