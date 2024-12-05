using Paint.Figures;

namespace Paint.States;

internal interface ISelection {
    public IFigure? SelectedFigure { get; set; }
    public List<IFigure> Figures { get; set; }
    public List<IFigure> SelectedFigures { get; set; }

    public bool IsMoving { get; set; }
    public Size CanvasSize { get; set; }
    public Point DragStartPoint { get; set; }
}
