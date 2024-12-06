using Paint.Interfaces;
using System.Text.Json;

namespace Paint.Serialization;

internal class HashableCanvas(Size size, string? name, List<HashableFigure> figures) {
    public Size CanvasSize { get; set; } = size;
    public string? CanvasName { get; set; } = name;
    public List<HashableFigure> Figures { get; set; } = figures;

    private static JsonSerializerOptions SerializerOptions { get; set; } = new JsonSerializerOptions { WriteIndented = true };

    public static void SaveFile(Size size, string? name, List<IDrawable> figures) {
        try {
            var canvasData = new HashableCanvas(size, name, HashableFigure.Serialize(figures));
            string json = JsonSerializer.Serialize(canvasData, SerializerOptions);

            using var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                File.WriteAllText(saveFileDialog.FileName, json);
                _ = MessageBox.Show("Файл сохранен!");
            }
        } catch (Exception ex) {
            _ = MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}");
        }
    }

    public static HashableCanvas? OpenFile() {
        var openFileDialog = new OpenFileDialog {
            InitialDirectory = Environment.CurrentDirectory,
            Filter = "Графический редактор (*.png)|*.png|All files(*.*)|*.*",
            FilterIndex = 1
        };

        HashableCanvas? canvas = null;

        try {
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                string canvasData = File.ReadAllText(openFileDialog.FileName);
                canvas = JsonSerializer.Deserialize<HashableCanvas>(canvasData, SerializerOptions);

                if (canvas is not null) {
                    canvas.CanvasName = canvas.CanvasName is null ? openFileDialog.FileName : canvas.CanvasName;
                }
            }
        } catch (Exception ex) {
            _ = MessageBox.Show("Error opening file: " + ex.Message);
        }

        return canvas;
    }
}

// 1) Получаешь HashableCanvas через HashableCanvas.OpenFile()
// 2) Получаешь из HashableCanvas.Figures List<IFigure>
