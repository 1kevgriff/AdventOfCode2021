// play bingo

public class BingoBoard
{
    public BingoSpot[,] Board { get; set; } = new BingoSpot[5, 5];
    public void Play(int number){
        for(int x = 0; x< Board.GetLength(0); x++){
            for(int y = 0; y< Board.GetLength(1); y++){
                if(Board[x,y].Number == number){
                    Board[x,y].IsFilled = true;
                }
            }
        }
    }

    public bool IsWinner()
    {
        // check rows
        for (int x = 0; x < 5; x++)
        {
            if (Board[x, 0].IsFilled &&
                Board[x, 1].IsFilled &&
                Board[x, 2].IsFilled &&
                Board[x, 3].IsFilled &&
                Board[x, 4].IsFilled)
            {
                return true;
            }
        }

        // check columns
        for (int y = 0; y < 5; y++)
        {
            if (Board[0, y].IsFilled &&
                Board[1, y].IsFilled &&
                Board[2, y].IsFilled &&
                Board[3, y].IsFilled &&
                Board[4, y].IsFilled)
            {
                return true;
            }
        }
        
        return false;
    }

    public int Score(int winningNumber) {
        int score = 0;
        for(int x = 0; x< Board.GetLength(0); x++){
            for(int y = 0; y< Board.GetLength(1); y++){
                if(!Board[x,y].IsFilled){
                    score += Board[x,y].Number;
                }
            }
        }

        return score * winningNumber;
    }

    public void AddLine(string line, int row)
    {
        if (string.IsNullOrWhiteSpace(line)) throw new NullReferenceException("Line is null or empty");

        var lineArray = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        for (int x = 0; x < 5; x++)
        {
            var spot = new BingoSpot()
            {
                Number = int.Parse(lineArray[x]),
                IsFilled = false
            };

            Board[row, x] = spot;
        }
    }
    public void PrintBoard()
    {
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                if (Board[x, y].IsFilled) Console.ForegroundColor = ConsoleColor.White;
                else Console.ResetColor();

                Console.Write($"{Board[x, y].Number}\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
    public class BingoSpot
    {
        public int Number { get; set; }
        public bool IsFilled { get; set; }
    }
}