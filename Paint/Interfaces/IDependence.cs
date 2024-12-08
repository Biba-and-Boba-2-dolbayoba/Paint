using System.Collections.Generic;
using System.Drawing;

namespace Paint.Interfaces;
internal interface IDependence;

internal interface ICanvasSize : IDependence {
    public Size CanvasSize { get; set; }
}

internal interface IFigures : IDependence {
    public List<IDrawable> Figures { get; set; }
}

internal interface IFigureType : IDependence {
    public FiguresEnum FigureType { get; set; }
}

internal interface IDrawTools : IDependence {
    public int PenSize { get; set; }
    public Color PenColor { get; set; }
    public Color BrushColor { get; set; }
    public bool IsFilling { get; set; }
}

internal interface IPoints : IDependence {
    public List<Point> Points { get; set; }
}

internal interface IText : IDependence {
    public string Text { get; set; }
    public Font TextFont { get; set; }
}

internal interface ITopBottomPoints : IDependence {
    public Point TopPoint { get; set; }
    public Point BotPoint { get; set; }
}

internal interface ITolerance : IDependence {
    public int Tolerance { get; set; }
}

internal interface IStartEndPoints : IDependence {
    public Point StartPoint { get; set; }
    public Point EndPoint { get; set; }
}