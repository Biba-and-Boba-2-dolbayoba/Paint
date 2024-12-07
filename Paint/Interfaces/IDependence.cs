namespace Paint.Interfaces;

internal interface IDependence {

}

internal interface ICanvasSizeDependence : IDependence {
    public Size CanvasSize { get; set; }
}

internal interface IFiguresDependence : IDependence {
    public List<IDrawable> Figures { get; set; }
}

internal interface IFigureTypeDependence : IDependence {
    public FiguresEnum FigureType { get; set; }
}

internal interface IDrawDependence : IDependence {
    public int PenSize { get; set; }
    public Color PenColor { get; set; }
    public Color BrushColor { get; set; }
    public bool IsFilling { get; set; }
}

internal interface IPointsDependence : IDependence {
    public List<Point> Points { get; set; }
}

internal interface ITextDependence : IDependence {
    public string Text { get; set; }
    public Font TextFont { get; set; }
}

internal interface ITopBottomDependence : IDependence {
    public Point TopPoint { get; set; }
    public Point BotPoint { get; set; }
}