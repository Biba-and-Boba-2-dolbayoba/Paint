using Newtonsoft.Json;
using Paint.Interfaces;

namespace Paint.Serialization.Models;

internal class HashableFigure {
    [JsonProperty("pen_size")]
    public required int PenSize { get; set; }

    [JsonProperty("pen_color")]
    public required string PenColor { get; set; }

    [JsonProperty("brush_color")]
    public required string BrushColor { get; set; }

    [JsonProperty("top_point")]
    public required Tuple<int, int> TopPoint { get; set; }

    [JsonProperty("bot_point")]
    public required Tuple<int, int> BotPoint { get; set; }

    [JsonProperty("is_filling")]
    public required bool IsFilling { get; set; }

    [JsonProperty("type")]
    public required FiguresEnum FigureType { get; set; }

    [JsonProperty("text")]
    public required string Text { get; set; }

    [JsonProperty("font_name")]
    public required string FontName { get; set; }

    [JsonProperty("font_size")]
    public required float FontSize { get; set; }

    [JsonProperty("points")]
    public required List<Point> Points { get; set; }
}
