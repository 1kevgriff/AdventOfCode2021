// See https://aka.ms/new-console-template for more information

var lines = System.IO.File.ReadAllLines("input.txt");

var horizontal = 0;
var depth = 0;
var aim = 0;

foreach (var l in lines)
{
    var split = l.ToLower().Split(' '); // command / value
    switch (split[0])
    {
        case "forward": 
            horizontal += int.Parse(split[1]); 
            depth += aim * int.Parse(split[1]);

            break;
        case "up": aim -= int.Parse(split[1]); break;
        case "down": aim += int.Parse(split[1]); break;
        default: throw new Exception("Unknown command");
    }

    Console.WriteLine($"{split[0]} {split[1]} -- ({horizontal}),({depth})");
}

Console.WriteLine("Horizontal: " + horizontal);
Console.WriteLine("Depth: " + depth);
Console.WriteLine("Final: " + depth *horizontal);