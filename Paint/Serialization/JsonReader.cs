using Newtonsoft.Json;
using Paint.Figures;
using Paint.Interfaces;
using Paint.Serialization.Models;

namespace Paint.Serialization;

internal static class JsonReader {
    private static Dictionary<FiguresEnum, Type> WrapperTypes { get; set; } = new() {
        { FiguresEnum.Rectangle, typeof(RectangleWrapper) },
        { FiguresEnum.Ellipse, typeof(EllipseWrapper) },
        { FiguresEnum.StraightLine, typeof(StraightLineWrapper) },
        { FiguresEnum.CurveLine, typeof(CurveLineWrapper) },
        { FiguresEnum.TextBox, typeof(TextBoxWrapper) },
    };

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

            if (figure is TextBoxWrapper _textBoxWrapper) {
                hashableFigure.Text = _textBoxWrapper.Text;
                hashableFigure.FontName = _textBoxWrapper.TextFont.Name;
                hashableFigure.FontSize = _textBoxWrapper.TextFont.Size;
            }

            if (figure is CurveLineWrapper _curveLineWrapper) {
                hashableFigure.Points = _curveLineWrapper.Points;
            }

            hashableFigures.Add(hashableFigure);
        }

        return hashableFigures;
    }

    public static List<IDrawable> ToDrawable(List<HashableFigure> hashableFigures) {
        List<IDrawable> figures = [];

        foreach (HashableFigure hashableFigure in hashableFigures) {
            IDrawable? wrapper = (IDrawable?)Activator.CreateInstance(WrapperTypes[hashableFigure.FigureType]);

            if (wrapper is null) {
                continue;
            }

            wrapper.PenSize = hashableFigure.PenSize;
            wrapper.PenColor = Color.FromArgb(Convert.ToInt32(hashableFigure.PenColor, 16));
            wrapper.BrushColor = Color.FromArgb(Convert.ToInt32(hashableFigure.BrushColor, 16));
            wrapper.TopPoint = new Point(hashableFigure.TopPoint.Item1, hashableFigure.TopPoint.Item2);
            wrapper.BotPoint = new Point(hashableFigure.BotPoint.Item1, hashableFigure.BotPoint.Item2);
            wrapper.IsFilling = hashableFigure.IsFilling;
            wrapper.FigureType = hashableFigure.FigureType;

            if (wrapper is TextBoxWrapper textBoxWrapper) {
                textBoxWrapper.Text = hashableFigure.Text;
                textBoxWrapper.TextFont = new(hashableFigure.Text, hashableFigure.FontSize);
            }

            if (wrapper is CurveLineWrapper curveLineWrapper) {
                curveLineWrapper.Points = hashableFigure.Points;
            }

            figures.Add(wrapper);
        }

        return figures;
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
