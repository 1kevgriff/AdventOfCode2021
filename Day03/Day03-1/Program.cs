// See https://aka.ms/new-console-template for more information

var input = await File.ReadAllTextAsync("input.txt");
var lines = input.Split(Environment.NewLine);

var gammaRate = ""; // most common bit
var epsilonRate = ""; // least common bit

var firstLine = lines.First();

for(int x = 0; x < firstLine.Length; x++)
{
    var countZero = lines.Count(c => c[x] == '0');
    var countOnes = lines.Count(c => c[x] == '1');

    if (countZero > countOnes)
    {
        gammaRate += "0";
        epsilonRate += "1";
    } else if (countOnes > countZero) {
        gammaRate += "1";
        epsilonRate += "0";
    } else {
        Console.WriteLine("Error: bits are equal");
    }
}

foreach (var l in lines){
    Console.WriteLine($"{l}");
}

var gammaAsInt = Convert.ToInt32(gammaRate, 2);
var epsilonAsInt = Convert.ToInt32(epsilonRate, 2);


Console.WriteLine($"Gamma: {gammaRate} or {gammaAsInt}");
Console.WriteLine($"Epsilon: {epsilonRate} or {epsilonAsInt}");
Console.WriteLine($"Power Consumption: {gammaAsInt * epsilonAsInt}");


