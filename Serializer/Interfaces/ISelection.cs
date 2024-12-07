namespace Serializer.Interfaces;
using System.Drawing;

internal interface ISelection : ICanvasSizeDepends {
    public List<IDrawable> Figures { get; set; }
    public List<IDrawable> SelectedFigures { get; set; }

    public bool IsMoving { get; set; }
    public Point DragStartPoint { get; set; }
}
