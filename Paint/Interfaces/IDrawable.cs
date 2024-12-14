using Paint.Figures;
using System.Collections.Generic;
using System.Drawing;

namespace Paint.Interfaces;

internal enum FigureTypes {
    Rectangle,
    Ellipse,
    StraightLine,
    CurveLine,
    TextBox
}

internal enum ResizePointsEnum {
    TopLeft,
    TopRight,
    BotRight,
    BotLeft,
    MiddleTop,
    MiddleRight,
    MiddleBot,
    MiddleLeft
}

internal interface IDrawable : IFigureType, IMovable, IDrawTools {
    public Dictionary<ResizePointsEnum, Point> ResizePointsDict { get; set; }
    public Dictionary<ResizePointsEnum, EllipseWrapper> GetResizeCircles();
    public void UpdateResizePointsDict();
    public void Draw(Graphics graphics);
    public void DrawDash(Graphics graphics);
    public void DrawSelection(Graphics graphics);
    public void DrawResizing(Graphics graphics);
    public bool ContainsPoint(Point point);
}
