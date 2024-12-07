using Serializer.Serialization;

namespace Serializer;

internal class Program {
    private static void Main(string[] args) {
        //JsonReader.Save();
        Serialization.Models.HashableCanvas? canvas = JsonReader.Open("D:\\Download\\file2.json");
        Console.WriteLine(canvas?.Figures[0].PenColor);
    }
}
