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
    public static Dictionary<FiguresEnum, WeakReference<IDrawable>> FigureTypes { get; set; } = [];
    public HashableFigure() {
        var rectangleWrapper = new RectangleWrapper();
        FigureTypes.Add(FiguresEnum.Rectangle, new WeakReference<IDrawable>(rectangleWrapper));
        var ellipseWrapper = new RectangleWrapper();
        FigureTypes.Add(FiguresEnum.Rectangle, new WeakReference<IDrawable>(ellipseWrapper));
        var curveLineWrapper = new RectangleWrapper();
        FigureTypes.Add(FiguresEnum.Rectangle, new WeakReference<IDrawable>(curveLineWrapper));
        var straightLineleWrapper = new RectangleWrapper();
        FigureTypes.Add(FiguresEnum.Rectangle, new WeakReference<IDrawable>(straightLineleWrapper));
        var textBoxWrapper = new RectangleWrapper();
        FigureTypes.Add(FiguresEnum.Rectangle, new WeakReference<IDrawable>(textBoxWrapper));
    }
    public FiguresEnum FigureType { get; set; }

    public string? Text { get; set; }
    public string? FontName { get; set; }
    public float? FontSize { get; set; }

    public List<Point>? Points { get; set; }

    public static Dictionary<FiguresEnum, WeakReference<IDrawable>> FigureTypes { get; set; } = [];

    public HashableFigure() {
        var rectangleWrapper = new RectangleWrapper();
        FigureTypes.Add(FiguresEnum.Rectangle, new WeakReference<IDrawable>(rectangleWrapper));

        
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
                StartPoint = figure.TopPoint,
                EndPoint = figure.BotPoint,
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

        IDrawable figureType = new RectangleWrapper();

        FigureTypes[FiguresEnum.Rectangle].TryGetTarget(out IDrawable? figure);

        if (figure is CurveLineWrapper curve) {
            curve.Po
        }

        return figureJsonList;
    }

    public static List<IDrawable> Deserialize(List<HashableFigure> figures) {
        var deserializedFigures = new List<IDrawable>();
        IDrawable figureType;

        foreach (var figure in figures) {
            IDrawable deserializedFigure;
            //figureType = (IDrawable)FigureTypes[figure.FigureType].GetConstructors()[0].Invoke(null);
            figureType = (IDrawable)FigureTypes[figure.FigureType];
            if (figure.Points is not null ) {
                deserializedFigure = new CurveLineWrapper {
                    PenSize = figure.PenSize,
                    PenColor = Color.FromArgb(Convert.ToInt32(figure.PenColor)),
                    BrushColor = Color.FromArgb(Convert.ToInt32(figure.BrushColor)),
                    TopPoint = figure.StartPoint,
                    BotPoint = figure.EndPoint,
                    IsFilling = figure.IsFilling,
                    FigureType = figure.FigureType,
                    Points = figure.Points
                };            
            }
            if (figure.FontName is not null && figure.FontSize is not null && figure.Text is not null) {
                deserializedFigure = new TextBoxWrapper {
                    PenSize = figure.PenSize,
                    PenColor = Color.FromArgb(Convert.ToInt32(figure.PenColor)),
                    BrushColor = Color.FromArgb(Convert.ToInt32(figure.BrushColor)),
                    TopPoint = figure.StartPoint,
                    BotPoint = figure.EndPoint,
                    IsFilling = figure.IsFilling,
                    FigureType = figure.FigureType,
                    Text = figure.Text,
                    TextFont = new Font(figure.FontName, (float)figure.FontSize)
                };
            }

            FigureTypes[FiguresEnum.Rectangle].TryGetTarget(out IDrawable? figure);

            deserializedFigures.Add(deserializedFigure);
        }

        return figure;
    }
}
