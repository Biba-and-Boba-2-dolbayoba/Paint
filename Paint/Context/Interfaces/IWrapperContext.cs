using Paint.Enums;
using System.Drawing;

namespace Paint.Context.Interfaces;

internal interface IWrapperContext {
    public FigureTypes FigureType { get; set; }

    public int PenSize { get; set; }
    public Color PenColor { get; set; }
    public bool IsFilling { get; set; }
    public Color FillingColor { get; set; }
    public Point StartPoint { get; set; }
    public Point EndPoint { get; set; }
}
