using Paint.Context.Interfaces;
using System.Drawing;
using System.Numerics;
using System;

namespace Paint.Components.Interfaces;

internal interface IMovingComponent {
    public IWrapperContext Context { get; set; }

    public Tuple<Point, Point> GetTopBotPoints();
    public bool CanMove(Point topLeft, Point botRight, Vector2 direction);
    public void Move(Point topLeft, Point botRight, Vector2 direction);
}
