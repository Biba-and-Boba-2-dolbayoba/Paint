namespace Paint.Interfaces;

internal interface ISelection : ICanvasSizeDependence, IFiguresDependence {
    public List<IDrawable> SelectedFigures { get; set; }

    public bool IsMoving { get; set; }
    public Point DragStartPoint { get; set; }
}
