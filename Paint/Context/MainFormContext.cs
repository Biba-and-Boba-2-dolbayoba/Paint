using Paint.Enums;
using Paint.States;
using Paint.States.Interfaces;
using System.Drawing;

namespace Paint.Context;

//TODO: Make Singleton
internal class MainFormContext {
    public Size CanvasSize { get; set; } = new Size(320, 240);
    public int PenSize { get; set; } = 2;
    public Color PenColor { get; set; } = Color.Black;
    public bool IsFilling { get; set; } = false;
    public Color FillingColor { get; set; } = Color.White;
    public Font TextFont { get; set; } = new("Times New Roman", 12.0f);
    public FigureTypes CurrentFigure { get; set; } = FigureTypes.Rectangle;
    public IState CurrentState { get; set; } = new DrawState();
    public bool IsGridEnabled { get; set; } = false;
    public int GridStep { get; set; } = 10;
    public bool SnapToGrid { get; set; } = false;
}
