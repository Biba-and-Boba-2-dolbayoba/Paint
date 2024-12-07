using Paint.Interfaces;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace Paint.Serialization;

internal class HashableCanvas(Size size, List<HashableFigure> figures) {
    public Size CanvasSize { get; set; } = size;
    public List<HashableFigure> Figures { get; set; } = figures;

    private static JsonSerializerOptions SerializerOptions { get; set; } = new JsonSerializerOptions { 
        WriteIndented = true, IncludeFields = true 
    };
    private static JsonTypeInfo<HashableFigure> Meta = JsonTypeInfo.CreateJsonTypeInfo<HashableFigure>(SerializerOptions);

    //public HashableCanvas() {
    //    List<JsonPropertyInfo> properties = [];
    //}

    public static void SaveFile(Size size, List<IDrawable> figures) {
        try {
            using var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                var canvasData = new HashableCanvas(size, HashableFigure.Serialize(figures));
                string json = JsonSerializer.Serialize(canvasData, SerializerOptions);

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
            Filter = "JSON-документ (*.json)|*.json|All files(*.*)|*.*",
            FilterIndex = 1
        };

        HashableCanvas? canvas = null;

        try {
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                using var stream = File.OpenRead(openFileDialog.FileName);
                JsonDocument canvasData = JsonDocument.Parse(stream);
                canvas = JsonSerializer.Deserialize<HashableCanvas>(canvasData, SerializerOptions);
            }
        } catch (Exception ex) {
            _ = MessageBox.Show("Error opening file: " + ex.Message);
        }

        return canvas;
    }
}
