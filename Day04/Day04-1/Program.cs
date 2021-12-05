// See https://aka.ms/new-console-template for more information
var inputFileText = (await File.ReadAllTextAsync("input.txt"))
                    .Split(Environment.NewLine);

var bingoInput = (inputFileText.First()).Split(',');

var boards = new List<BingoBoard>();
for (int x = 2; x < inputFileText.Length; x += 6)
{
    var board = new BingoBoard();
    board.AddLine(inputFileText[x], 0);
    board.AddLine(inputFileText[x + 1], 1);
    board.AddLine(inputFileText[x + 2], 2);
    board.AddLine(inputFileText[x + 3], 3);
    board.AddLine(inputFileText[x + 4], 4);
    board.PrintBoard();

    boards.Add(board);
}

foreach( var play in bingoInput)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Playing: " + play);
    Console.ResetColor();

    foreach(var board in boards)
    {
        board.Play(int.Parse(play));

        if (board.IsWinner()){
            Console.WriteLine("Winner!");
            board.PrintBoard();
            Console.WriteLine("Score: " + board.Score(int.Parse(play)));
            return;
        }
    }
}