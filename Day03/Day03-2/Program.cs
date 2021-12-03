// See https://aka.ms/new-console-template for more information

var input = await File.ReadAllTextAsync("input.txt");
var lines = input.Split(Environment.NewLine).ToList();

int position = 0;
int o2Generator = 0;
int co2Scrubber = 0;

for (var x = 0; x < lines.First().Length; x++)
{
    // WriteOutput(lines, x);
    lines = ReduceListToMostCommonBit(lines, x);
    if (lines.Count() == 1) break;
}
// WriteOutput(lines, -1);
o2Generator = Convert.ToInt32(lines.First(), 2);

lines = input.Split(Environment.NewLine).ToList();
for (var x = 0; x < lines.First().Length; x++)
{
    WriteOutput(lines, x);
    lines = ReduceListToLeastCommonBit(lines, x);
    if (lines.Count() == 1) break;
}
WriteOutput(lines, -1);
co2Scrubber = Convert.ToInt32(lines.First(), 2);

Console.WriteLine($"o2 Generator: {o2Generator}");
Console.WriteLine($"CO2 Scrubber: {co2Scrubber}");
Console.WriteLine("Life Support: " + (o2Generator * co2Scrubber));

void WriteOutput(List<string> lines, int iteration)
{
    Console.WriteLine($"Iteration {iteration}");
    foreach (var l in lines)
    {
        Console.WriteLine(l);
    }
}

// Figure out Gamma and Epsilon
List<string> ReduceListToMostCommonBit(List<string> lines, int position)
{
    var firstLine = lines.First();
    var gammaRate = ""; // most common bit
    var epsilonRate = ""; // least common bit
    for (int x = 0; x < firstLine.Length; x++)
    {
        var countZero = lines.Count(c => c[x] == '0');
        var countOnes = lines.Count(c => c[x] == '1');

        if (countZero > countOnes)
        {
            gammaRate += "0";
            epsilonRate += "1";
        }
        else
        {
            gammaRate += "1";
            epsilonRate += "0";
        }
    }

    // what's value at position x in gamma)
    var reduced = lines.Where(p => p[position] == gammaRate[position]).ToList();
    return reduced;
}

List<string> ReduceListToLeastCommonBit(List<string> lines, int position)
{
    var firstLine = lines.First();
    var gammaRate = ""; // most common bit
    var epsilonRate = ""; // least common bit
    for (int x = 0; x < firstLine.Length; x++)
    {
        var countZero = lines.Count(c => c[x] == '0');
        var countOnes = lines.Count(c => c[x] == '1');

        if (countZero > countOnes)
        {
            gammaRate += "0";
            epsilonRate += "1";
        }
        else
        {
            gammaRate += "1";
            epsilonRate += "0";
        }
    }

    // what's value at position x in gamma)
    var reduced = lines.Where(p => p[position] == epsilonRate[position]).ToList();
    return reduced;
}