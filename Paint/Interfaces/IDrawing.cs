namespace Paint.Interfaces;

internal interface IDrawing :
IDrawDependence, ICanvasSizeDependence,
ITopBottomDependence, ITextDependence,
IPointsDependence, IFigureTypeDependence, IFiguresDependence {
    public bool IsDrawing { get; set; }
    public Tuple<IDrawable?, IDrawable?> DashFigures { get; set; }
    public BufferedGraphics? GraphicsBuffer { get; set; }
}
