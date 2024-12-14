using System.Collections.Generic;
using System.Drawing;

namespace Paint.Context.Interfaces;

internal interface ICurveLineContext {
    public int Tolerance { get; set; }
    public List<Point> Points { get; set; }
}
