using Newtonsoft.Json;
using Serializer.Interfaces;
using System.Drawing;

namespace Serializer.Serialization.Models;

internal class HashableFigure {
    [JsonProperty("pen_size")]
    public int PenSize { get; set; } = 2;

    [JsonProperty("pen_color")]
    public string PenColor { get; set; } = "";

    [JsonProperty("brush_color")]
    public string BrushColor { get; set; } = "";

    [JsonProperty("top_point")]
    public Tuple<int, int> TopPoint = new(0, 0);

    [JsonProperty("bot_point")]
    public Tuple<int, int> BotPoint = new(0, 0);

    [JsonProperty("is_filling")]
    public bool IsFilling { get; set; } = false;

    [JsonProperty("type")]
    public FiguresEnum FigureType { get; set; }

    [JsonProperty("text")]
    public string Text { get; set; } = "";

    [JsonProperty("font_name")]
    public string FontName { get; set; } = "";

    [JsonProperty("font_size")]
    public float FontSize { get; set; } = 0;

    [JsonProperty("points")]
    public List<Point> Points { get; set; } = [];
}
