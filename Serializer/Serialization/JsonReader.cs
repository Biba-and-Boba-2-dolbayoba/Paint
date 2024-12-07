using Newtonsoft.Json;
using Serializer.Figures;
using Serializer.Interfaces;
using Paint.Serialization.Models;
using System.Drawing;
using Serializer.Serialization.Models;

namespace Serializer.Serialization;

internal static class JsonReader {
    private static List<HashableFigure> ToHashableFigures(List<IDrawable> figures) {
        List<HashableFigure> hashableFigures = [];

        foreach (IDrawable figure in figures) {
            var hashableFigure = new HashableFigure() {
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
                FigureType = figure.FigureType
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

    public static void Save(Size size, List<IDrawable> figures, string fileName) {

                Tuple<int, int> canvasSize = new(size.Width, size.Height);
                List<HashableFigure> hashableFigures = ToHashableFigures(figures);

                var canvas = new HashableCanvas() {
                    CanvasSize = canvasSize,
                    Figures = hashableFigures,
                };

                string json = JsonConvert.SerializeObject(canvas);
                string path = Path.GetFullPath(fileName);

                File.WriteAllText(path, json);;
    }

    public static HashableCanvas? Open(string path) {
        string json = File.ReadAllText(path);

        HashableCanvas? canvas = JsonConvert.DeserializeObject<HashableCanvas?>(json);

        return canvas;
    }
}
