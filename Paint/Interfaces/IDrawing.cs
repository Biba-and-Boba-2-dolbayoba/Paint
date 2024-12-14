using System.Drawing;

namespace Paint.Interfaces;
internal interface IDrawing :
IDrawTools, ICanvasSize,
ITopBottomPoints, IText,
IPoints, IFigureType, IFigures {
    public bool IsDrawing { get; set; }
    public IDrawable? DashFigure { get; set; }
    public CanvasForm? ParentReference { get; set; }
    public BufferedGraphics? GraphicsBuffer { get; set; }
}
