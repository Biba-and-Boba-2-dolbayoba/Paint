using Paint.Figures;

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

    public static List<HashableFigure> Serialize(List<IFigure> figures) {
        List<HashableFigure> figureJsonList = [];

        foreach (IFigure figure in figures) {
            var figureJson = new HashableFigure() {
                PenSize = figure.PenSize,
                PenColor = Convert.ToHexString(
                    [figure.PenColor.A, figure.PenColor.R, figure.PenColor.G, figure.PenColor.B]
                ),
                BrushColor = Convert.ToHexString(
                    [figure.BrushColor.A, figure.BrushColor.R, figure.BrushColor.G, figure.BrushColor.B]
                ),
                StartPoint = figure.StartPoint,
                EndPoint = figure.EndPoint,
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

    public static List<IFigure> Deserialize(List<HashableFigure> figures) {
        var deserializedFigures = new List<IFigure>();

        foreach (var figure in figures) {
            IFigure deserializedFigure;

            
            if (!string.IsNullOrEmpty(figure.Text)) 
            {
                deserializedFigure = new TextBoxWrapper {
                    Text = figure.Text,
                    TextFont = new Font(figure.FontName ?? "Arial", figure.FontSize ?? 12),
                    PenSize = figure.PenSize,
                    PenColor = Color.FromArgb(Convert.ToInt32(figure.PenColor)),
                    BrushColor = Color.FromArgb(Convert.ToInt32(figure.BrushColor)),
                    StartPoint = figure.StartPoint,
                    EndPoint = figure.EndPoint,
                    IsFilling = figure.IsFilling
                };
            } else if (figure.Points != null && figure.Points.Count > 0) 
              {
                deserializedFigure = new CurveLineWrapper {
                    Points = figure.Points,
                    PenSize = figure.PenSize,
                    PenColor = Color.FromArgb(Convert.ToInt32(figure.PenColor)),
                    BrushColor = Color.FromArgb(Convert.ToInt32(figure.BrushColor)),
                    StartPoint = figure.StartPoint,
                    EndPoint = figure.EndPoint,
                    IsFilling = figure.IsFilling
                };
            } else 
              {
                deserializedFigure = new BaseFigure {
                    PenSize = figure.PenSize,
                    PenColor = Color.FromArgb(Convert.ToInt32(figure.PenColor)),
                    BrushColor = Color.FromArgb(Convert.ToInt32(figure.BrushColor)),
                    StartPoint = figure.StartPoint,
                    EndPoint = figure.EndPoint,
                    IsFilling = figure.IsFilling
                };
            }

            deserializedFigures.Add(deserializedFigure);
        }

        return deserializedFigures;
    }
}
