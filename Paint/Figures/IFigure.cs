namespace Paint.Figures;

internal enum FiguresEnum {
    Rectangle,
    Ellipse,
    Line,
    CurveLine,
    TextBox
}

internal interface IFigure : IMovable {
    public int PenSize { get; set; }
    public Color PenColor { get; set; }
    public Color BrushColor { get; set; }
    public bool IsFilling { get; set; }
    public Point StartPoint { get; set; }
    public Point EndPoint { get; set; }

    public void Draw(Graphics graphics);

    public void Hide(Graphics graphics);

    public void DrawDash(Graphics graphics);

    public void DrawSelection(Graphics graphics);

    public bool ContainsPoint(Point point);
}
