using System.Drawing;

namespace Serializer.Interfaces;
internal interface IDrawing : IDrawDepends, ICanvasSizeDepends, ITopBottomDepends, ITextDepends {
    public bool IsDrawing { get; set; }

    public List<Point> Points { get; set; }

    public FiguresEnum FigureType { get; set; }
    public Tuple<IDrawable?, IDrawable?> DashFigures { get; set; }
    public List<IDrawable> Figures { get; set; }

    public BufferedGraphics? GraphicsBuffer { get; set; }
}
