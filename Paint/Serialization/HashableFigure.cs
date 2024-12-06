using Paint.Figures;
using Paint.Interfaces;

namespace Paint.Serialization;

internal class HashableFigure {
    public int PenSize { get; set; } = 2;
    public string PenColor { get; set; } = "";
    public string BrushColor { get; set; } = "";
    public Point TopPoint { get; set; } = new(0, 0);
    public Point BotPoint { get; set; } = new(0, 0);
    public bool IsFilling { get; set; } = false;
    public FiguresEnum FigureType { get; set; }

    public string Text { get; set; } = "";
    public string FontName { get; set; } = "";
    public float FontSize { get; set; } = 0;

    public List<Point> Points { get; set; } = [];

    private static Dictionary<FiguresEnum, WeakReference<IDrawable>> FigureTypes { get; set; } = [];

    public HashableFigure() {
        var rectangleWrapper = new RectangleWrapper();
        var ellipseWrapper = new EllipseWrapper();
        var straightLineWrapper = new StraightLineWrapper();
        var curveLineWrapper = new CurveLineWrapper();
        var textBoxWrapper = new TextBoxWrapper();

        FigureTypes.Add(FiguresEnum.Rectangle, new WeakReference<IDrawable>(rectangleWrapper));
        FigureTypes.Add(FiguresEnum.Ellipse, new WeakReference<IDrawable>(ellipseWrapper));
        FigureTypes.Add(FiguresEnum.StraightLine, new WeakReference<IDrawable>(straightLineWrapper));
        FigureTypes.Add(FiguresEnum.CurveLine, new WeakReference<IDrawable>(curveLineWrapper));
        FigureTypes.Add(FiguresEnum.TextBox, new WeakReference<IDrawable>(textBoxWrapper));
    }

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
                TopPoint = figure.TopPoint,
                BotPoint = figure.BotPoint,
                IsFilling = figure.IsFilling,
                FigureType = figure.FigureType
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

    public static List<IDrawable> Deserialize(List<HashableFigure> figures) {
        var deserializedFigures = new List<IDrawable>();

        foreach (HashableFigure figure in figures) {
            _ = FigureTypes[FiguresEnum.Rectangle].TryGetTarget(out IDrawable? figureWrapper);

            if (figureWrapper is CurveLineWrapper) {
                IDrawable deserializedFigure = new CurveLineWrapper {
                    PenSize = figure.PenSize,
                    PenColor = Color.FromArgb(Convert.ToInt32(figure.PenColor)),
                    BrushColor = Color.FromArgb(Convert.ToInt32(figure.BrushColor)),
                    TopPoint = figure.TopPoint,
                    BotPoint = figure.BotPoint,
                    IsFilling = figure.IsFilling,
                    FigureType = figure.FigureType,
                    Points = figure.Points
                };

                deserializedFigures.Add(deserializedFigure);
            }

            if (figureWrapper is CurveLineWrapper) {
                IDrawable deserializedFigure = new TextBoxWrapper {
                    PenSize = figure.PenSize,
                    PenColor = Color.FromArgb(Convert.ToInt32(figure.PenColor)),
                    BrushColor = Color.FromArgb(Convert.ToInt32(figure.BrushColor)),
                    TopPoint = figure.TopPoint,
                    BotPoint = figure.BotPoint,
                    IsFilling = figure.IsFilling,
                    FigureType = figure.FigureType,
                    Text = figure.Text,
                    TextFont = new Font(figure.FontName, figure.FontSize)
                };

                deserializedFigures.Add(deserializedFigure);
            }

            if (figureWrapper is not null) {
                IDrawable deserializedFigure = figureWrapper;

                deserializedFigure.PenSize = figure.PenSize;
                deserializedFigure.PenColor = Color.FromArgb(Convert.ToInt32(figure.PenColor));
                deserializedFigure.BrushColor = Color.FromArgb(Convert.ToInt32(figure.BrushColor));
                deserializedFigure.TopPoint = figure.TopPoint;
                deserializedFigure.BotPoint = figure.BotPoint;
                deserializedFigure.IsFilling = figure.IsFilling;
                deserializedFigure.FigureType = figure.FigureType;

                deserializedFigures.Add(deserializedFigure);
            }
        }

        return deserializedFigures;
    }
}
