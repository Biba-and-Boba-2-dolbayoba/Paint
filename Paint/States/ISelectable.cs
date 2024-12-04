using Paint.Figures;

namespace Paint.States;

internal interface ISelectable {
    public Figure? SelectedFigure { get; set; }
    public List<Figure> Figures { get; set; }
    public List<Figure> SelectedFigures { get; set; }

    public Point Drag
}
