// See https://aka.ms/new-console-template for more information
Console.WriteLine("Advent of Code - Day 1 - Puzzle 2");

var data = await File.ReadAllLinesAsync("report.txt");
var input = data.Select(p => int.Parse(p)).ToList();

var measurements = new List<Measurement>() {
    new Measurement("A") { Data = new List<int>()}
};

for (int i = 0; i < input.Count; i++)
{
    measurements
    .Where(p => p.Data.Count() < 3)
    .ToList()
    .ForEach(p => p.Data.Add(input[i]));

    // add new measurement block
    var current = measurements.Last().Identifier.First();
    var nextLetter = ((int)current) + 1;
    measurements.Add(new Measurement($"{(char)nextLetter}"));
}

// remove last group if there aren't enough
measurements.RemoveAll(p => p.Data.Count() < 3);

var increases = 0;
var previousSum = 0;

foreach (var m in measurements)
{
    var sum = m.Data.Sum();
    if (previousSum != 0 && sum > previousSum) increases++;

    Console.Write($"{m.Identifier}: {sum} ");
    if (previousSum == 0) Console.WriteLine($"(N/A - no previous sum)");
    else if (previousSum != 0 && sum > previousSum) Console.WriteLine($"(increase)");
    else Console.WriteLine($"(decrease)");

    previousSum = sum;

}

Console.WriteLine("There are {0} increases", increases);

public class Measurement
{
    public Measurement(string v)
    {
        Identifier = v;
    }

    public string Identifier { get; set; } // A, B, C, D, etc
    public List<int> Data { get; set; } = new List<int>(); // List of data points
}
