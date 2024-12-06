using Paint.Figures;

namespace Paint.States;

internal interface IDrawing : ICanvasSizeDepended {
    public bool IsDrawing { get; set; }

    public Point StartPoint { get; set; }
    public Point EndPoint { get; set; }
    public List<Point> Points { get; set; }

    public int PenSize { get; set; }
    public Color PenColor { get; set; }
    public Color BrushColor { get; set; }
    public bool IsFilling { get; set; }

    public string Text { get; set; }
    public Font TextFont { get; set; }

    public FiguresEnum FigureType { get; set; }
    public Tuple<IFigure?, IFigure?> DashFigures { get; set; }
    public List<IFigure> Figures { get; set; }

    public BufferedGraphics? GraphicsBuffer { get; set; }
}
