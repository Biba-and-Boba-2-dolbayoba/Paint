using Newtonsoft.Json;

namespace Paint.Serialization.Models;

internal class HashableCanvas {
    [JsonProperty("canvas_size")]
    public Tuple<int, int> CanvasSize { get; set; } = new(0, 0);

    [JsonProperty("figures")]
    public List<HashableFigure> Figures { get; set; } = [];
}
