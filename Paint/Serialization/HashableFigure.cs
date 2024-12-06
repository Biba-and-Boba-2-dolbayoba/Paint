using Paint.Figures;
using Paint.Interfaces;

namespace Paint.Serialization;

internal class HashableFigure {
    public int PenSize { get; set; } = 2;
    public string PenColor { get; set; } = "";
    public string BrushColor { get; set; } = "";
    public Point StartPoint { get; set; } = new(0, 0);
    public Point EndPoint { get; set; } = new(0, 0);
    public bool IsFilling { get; set; } = false;

    public string? Text { get; set; }
    public string? FontName { get; set; }
    public float? FontSize { get; set; }

    public List<Point>? Points { get; set; }

    public static List<HashableFigure> Serialize(List<IDrawable> figures) {
        List<HashableFigure> figureJsonList = [];

        foreach (IDrawable figure in figures) {
            var figureJson = new HashableFigure() {
                PenSize = figure.PenSize,
                PenColor = Convert.ToHexString(
                    [figure.PenColor.A, figure.PenColor.R, figure.PenColor.G, figure.PenColor.B]
                ),
                BrushColor = Convert.ToHexString(
                    [figure.BrushColor.A, figure.BrushColor.R, figure.BrushColor.G, figure.BrushColor.B]
                ),
                StartPoint = figure.TopPoint,
                EndPoint = figure.BotPoint,
                IsFilling = figure.IsFilling,
            };

            if (figure is TextBoxWrapper textBoxWrapper) {
                figureJson.Text = textBoxWrapper.Text;
                figureJson.FontName = textBoxWrapper.TextFont.Name;
                figureJson.FontSize = textBoxWrapper.TextFont.Size;
            }

            if (figure is CurveLineWrapper curveLineWrapper) {
                figureJson.Points = curveLineWrapper.Points;
            }

            figureJsonList.Add(figureJson);
        }

        return figureJsonList;
    }

    //public static List<IFigure> Deserialize(List<HashableFigure> figures) {
    //Figure figure = new Rect {
    //    font = new Font(this.fontName, this.fontSize),
    //    line_color = Color.FromArgb(Convert.ToInt32(this.LineColor)),
    //    back_color = Color.FromArgb(Convert.ToInt32(this.BackColor)),
    //    point1 = this.Point1,
    //    point2 = this.Point2,
    //    text = this.Text,
    //    back_TF = this.BackTF,
    //    mas_points = this.MasPoints.ToArray()
    //};

    //return figure;
    //}
}
