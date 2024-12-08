using System.Drawing;

namespace Paint.Interfaces;
internal interface IDrawing :
IDrawDependence, ICanvasSizeDependence,
ITopBottomDependence, ITextDependence,
IPointsDependence, IFigureTypeDependence, IFiguresDependence {
    public bool IsDrawing { get; set; }
    public IDrawable? DashFigure { get; set; }
    public UiCanvasWindow? ParentReference { get; set; }
    public BufferedGraphics? GraphicsBuffer { get; set; }
}
