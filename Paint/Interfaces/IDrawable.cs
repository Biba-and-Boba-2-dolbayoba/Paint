namespace Paint.Interfaces;

internal enum FiguresEnum {
    Rectangle,
    Ellipse,
    Line,
    CurveLine,
    TextBox
}

internal interface IDrawDepends {
    public int PenSize { get; set; }
    public Color PenColor { get; set; }
    public Color BrushColor { get; set; }
    public bool IsFilling { get; set; }
}

internal interface ITextDepends {
    public string Text { get; set; }
    public Font TextFont { get; set; }
}

internal interface ITopBottomDepends {
    public Point TopPoint { get; set; }
    public Point BotPoint { get; set; }
}

internal interface IDrawable : IDrawDepends, IMovable {
    public void Draw(Graphics graphics);
    public void Hide(Graphics graphics);
    public void DrawDash(Graphics graphics);
    public void DrawSelection(Graphics graphics);
    public bool ContainsPoint(Point point);
}
