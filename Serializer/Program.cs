using Serializer.Serialization;
using Serializer.Figures;
using Serializer.Interfaces;

namespace Serializer;

internal class Program {
    static void Main(string[] args) {
        //JsonReader.Save();
        var canvas = JsonReader.Open("D:\\Download\\file2.json");
        Console.WriteLine(canvas?.Figures[0].PenColor);
    }
}
