using Newtonsoft.Json;
using Paint.Figures;
using Paint.Interfaces;
using Paint.Serialization.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Paint.Serialization;

internal static class JsonReader {
    private static Dictionary<FigureTypes, Type> WrapperTypes { get; set; } = new() {
        { FigureTypes.Rectangle, typeof(RectangleWrapper) },
        { FigureTypes.Ellipse, typeof(EllipseWrapper) },
        { FigureTypes.StraightLine, typeof(StraightLineWrapper) },
        { FigureTypes.CurveLine, typeof(CurveLineWrapper) },
        { FigureTypes.TextBox, typeof(TextBoxWrapper) },
    };

    public static List<HashableFigure> ToHashableFigures(List<IDrawable> figures) {
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
                StartPoint = new Tuple<int, int>(figure.TopPoint.X, figure.TopPoint.Y),
                EndPoint = new Tuple<int, int>(figure.BotPoint.X, figure.BotPoint.Y),
                Text = "",
                FontName = "",
                FontSize = 0,
                Points = []
            };

            if (figure is StraightLineWrapper straighLineWrapper) {
                hashableFigure.StartPoint = new Tuple<int, int>(straighLineWrapper.StartPoint.X, straighLineWrapper.StartPoint.Y);
                hashableFigure.EndPoint = new Tuple<int, int>(straighLineWrapper.EndPoint.X, straighLineWrapper.EndPoint.Y);
            }

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

    public static List<IDrawable> ToDrawable(List<HashableFigure> hashableFigures) {
        List<IDrawable> figures = [];

        foreach (HashableFigure hashableFigure in hashableFigures) {
            var wrapper = (IDrawable?)Activator.CreateInstance(WrapperTypes[hashableFigure.FigureType]);

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

            if (wrapper is StraightLineWrapper straighLineWrapper) {
                straighLineWrapper.StartPoint = new Point(hashableFigure.StartPoint.Item1, hashableFigure.StartPoint.Item2);
                straighLineWrapper.EndPoint = new Point(hashableFigure.EndPoint.Item1, hashableFigure.EndPoint.Item2);
            }

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

    public static string ToBufferString(List<IDrawable> figures) {
        List<HashableFigure> hashableFigures = ToHashableFigures(figures);

        var listOfHashableFigures = new ListOfHashableFigures {
            Figures = hashableFigures
        };
        string json = JsonConvert.SerializeObject(listOfHashableFigures);

        return json;
    }

    public static List<IDrawable> ToFigureList(string json) {
        ListOfHashableFigures? listOfHashableFigures = JsonConvert.DeserializeObject<ListOfHashableFigures>(json);

        return listOfHashableFigures is null ? ([]) : ToDrawable(listOfHashableFigures.Figures);
    }
}
