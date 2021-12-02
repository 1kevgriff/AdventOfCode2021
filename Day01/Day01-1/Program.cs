// See https://aka.ms/new-console-template for more information
Console.WriteLine("Advent of Code - Day 1 - Puzzle 1");

var input = new List<int>();

var data = await File.ReadAllLinesAsync("report.txt");
input = data.Select(p=> int.Parse(p)).ToList();

var increases = 0;

for(int i = 0; i < input.Count - 1; i++)
{
    Console.Write($"Comparing {input[i]} and {input[i + 1]}");
    if(input[i+1] > input[i])
    {
        Console.WriteLine(" - Increasing");
        increases++;
    } else {
        Console.WriteLine(" - Decreasing");
    }
}

Console.WriteLine("There are {0} increases", increases);
