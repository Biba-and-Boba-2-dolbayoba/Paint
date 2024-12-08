using System.Windows.Forms;

namespace Paint.Interfaces;
internal enum StatesEnum {
    DrawState,
    SelectState,
    EditState

}

internal interface IState : IFigures, ICanvasSize {
    public void MouseUpHandler(MouseEventArgs e);
    public void MouseMoveHandler(MouseEventArgs e);
    public void MouseDownHandler(MouseEventArgs e);
}
