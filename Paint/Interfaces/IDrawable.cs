using System.Drawing;

namespace Paint.Interfaces;
internal enum FiguresEnum {
    Rectangle,
    Ellipse,
    StraightLine,
    CurveLine,
    TextBox
}

internal interface IDrawable : IFigureTypeDependence, IMovable, IDrawDependence {
    public void Draw(Graphics graphics);
    public void DrawDash(Graphics graphics);
    public void DrawSelection(Graphics graphics);
    public bool ContainsPoint(Point point);
}
