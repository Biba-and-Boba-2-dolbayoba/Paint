using Paint.Figures;

namespace Paint.States;

internal interface ISelection {
    public Figure? SelectedFigure { get; set; }
    public List<Figure> Figures { get; set; }
    public List<Figure> SelectedFigures { get; set; }

    public bool IsMoving { get; set; }
    public Size CanvasSize { get; set; }
    public Point DragStartPoint { get; set; }
}
