using Newtonsoft.Json;
using Paint.Figures;
using Paint.Interfaces;
using Paint.Serialization.Models;

namespace Paint.Serialization;

internal static class JsonReader {
    private static RectangleWrapper rectangleWrapper = new();
    private static EllipseWrapper ellipseWrapper = new();
    private static StraightLineWrapper straightLineWrapper = new();
    private static CurveLineWrapper curveLineWrapper = new();
    private static TextBoxWrapper textBoxWrapper = new();
    private static Dictionary<FiguresEnum, WeakReference<IDrawable>> FigureTypes { get; set; } = new() {
        { FiguresEnum.Rectangle, new WeakReference<IDrawable>(rectangleWrapper) },
        { FiguresEnum.Ellipse, new WeakReference<IDrawable>(ellipseWrapper) },
        { FiguresEnum.StraightLine, new WeakReference<IDrawable>(straightLineWrapper) },
        { FiguresEnum.CurveLine, new WeakReference<IDrawable>(curveLineWrapper) },
        { FiguresEnum.TextBox, new WeakReference<IDrawable>(textBoxWrapper) },
    };

    public static List<IDrawable> ToDrawable(List<HashableFigure> hashableFigures) {
        List<IDrawable> figures = [];

        foreach (HashableFigure hashableFigure in hashableFigures) {
            _ = FigureTypes[hashableFigure.FigureType].TryGetTarget(out IDrawable? figureType);
            IDrawable? figure = figureType;

            if (figure is null) {
                continue;
            }

            figure.PenSize = hashableFigure.PenSize;
            figure.PenColor = Color.FromArgb(Convert.ToInt32(hashableFigure.PenColor, 16));
            figure.BrushColor = Color.FromArgb(Convert.ToInt32(hashableFigure.BrushColor, 16));
            figure.TopPoint = new Point(hashableFigure.TopPoint.Item1, hashableFigure.TopPoint.Item2);
            figure.BotPoint = new Point(hashableFigure.BotPoint.Item1, hashableFigure.BotPoint.Item2);
            figure.IsFilling = hashableFigure.IsFilling;
            figure.FigureType = hashableFigure.FigureType;

            if (figure is TextBoxWrapper textBoxWrapper) {
                textBoxWrapper.Text = hashableFigure.Text;
                textBoxWrapper.TextFont = new(hashableFigure.Text, hashableFigure.FontSize);
            }

            if (figure is CurveLineWrapper curveLineWrapper) {
                curveLineWrapper.Points = hashableFigure.Points;
            }

            figures.Add(figure);
        }

        return figures;
    }

    private static List<HashableFigure> ToHashableFigures(List<IDrawable> figures) {
        List<HashableFigure> hashableFigures = [];
        HashableFigure hashableFigure;

        foreach (IDrawable figure in figures) {
            hashableFigure = new HashableFigure() {
                PenSize = figure.PenSize,
                PenColor = Convert.ToHexString(
                    [figure.PenColor.A, figure.PenColor.R, figure.PenColor.G, figure.PenColor.B]
                ),
                BrushColor = Convert.ToHexString(
                    [figure.BrushColor.A, figure.BrushColor.R, figure.BrushColor.G, figure.BrushColor.B]
                ),
                TopPoint = new Tuple<int, int>(figure.TopPoint.X, figure.TopPoint.Y),
                BotPoint = new Tuple<int, int>(figure.BotPoint.X, figure.BotPoint.Y),
                IsFilling = figure.IsFilling,
                FigureType = figure.FigureType,
                Text = "",
                FontName = "",
                FontSize = 0,
                Points = []
            };

            if (figure is TextBoxWrapper textBoxWrapper) {
                hashableFigure.Text = textBoxWrapper.Text;
                hashableFigure.FontName = textBoxWrapper.TextFont.Name;
                hashableFigure.FontSize = textBoxWrapper.TextFont.Size;
            }

            if (figure is CurveLineWrapper curveLineWrapper) {
                hashableFigure.Points = curveLineWrapper.Points;
            }

            hashableFigures.Add(hashableFigure);
        }

        return hashableFigures;
    }

    public static void Save(Size size, List<IDrawable> figures) {
        try {
            using var saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                Tuple<int, int> canvasSize = new(size.Width, size.Height);
                List<HashableFigure> hashableFigures = ToHashableFigures(figures);

                var canvas = new HashableCanvas() {
                    CanvasSize = canvasSize,
                    Figures = hashableFigures,
                };

                string json = JsonConvert.SerializeObject(canvas);
                string path = Path.GetFullPath(saveFileDialog.FileName);

                File.WriteAllText(path, json);
                _ = MessageBox.Show("Файл сохранен!");
            }
        } catch (Exception ex) {
            _ = MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}");
        }
    }

    public static HashableCanvas? Open() {
        HashableCanvas? canvas = null;

        try {
            using var openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = Environment.CurrentDirectory;
            openFileDialog.Filter = "JSON-документ (*.json)|*.json|All files(*.*)|*.*";
            openFileDialog.FilterIndex = 1;

            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                string json = File.ReadAllText(openFileDialog.FileName);
                canvas = JsonConvert.DeserializeObject<HashableCanvas?>(json);
            }
        } catch (Exception ex) {
            _ = MessageBox.Show("Error opening file: " + ex.Message);
        }

        return canvas;
    }
}
