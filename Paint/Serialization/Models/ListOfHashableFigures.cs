using Newtonsoft.Json;

namespace Paint.Serialization.Models;

internal class ListOfHashableFigures {
    [JsonProperty("figures")]
    public required List<HashableFigure> Figures { get; set; }
}

