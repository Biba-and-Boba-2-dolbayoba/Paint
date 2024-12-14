using Paint.Context.Interfaces;
using System.Drawing;

namespace Paint.Components.Interfaces;

internal interface IVisualComponent {
    public IWrapperContext Context { get; set; }

    public void Draw(Graphics graphics);
    public void DrawDash(Graphics graphics);
    public void DrawSelection(Graphics graphics);
    public void DrawResizing(Graphics graphics);
    public void ContainsPoint(Point point);
    public void CollectResizePoint();
}
