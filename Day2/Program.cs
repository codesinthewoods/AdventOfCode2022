class Program
{
    static void CalculateTotalScoreByPlayerMoves(string filename)
    {
        try
        {
            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            string[] lines = File.ReadAllLines(filename);

            int totalScore = 0;
            foreach (string line in lines)
            {
                if (line.Trim() != "")
                {
                    string[] plays = line.Split(' ');
                    if (plays.Length == 2)
                    {
                        totalScore += CalculateRoundScore(plays[0], plays[1]);
                    }
                }
            }

            Console.WriteLine("Total score = " + totalScore);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static int CalculateRoundScore(string opponentPlay, string playerPlay)
    {
        int roundScore = 0;

        switch(playerPlay)
        {
            case "X": // Rock
                roundScore += 1;
                switch (opponentPlay)
                {
                    case "A": // Rock
                        roundScore += 3;
                        break;

                    case "B": // Paper
                        roundScore += 0;
                        break;

                    case "C": // Scissors
                        roundScore += 6;
                        break;
                    default:
                        throw new Exception("Invalid input");
                }
                break;

            case "Y": // Paper
                roundScore += 2;
                switch (opponentPlay)
                {
                    case "A": // Rock
                        roundScore += 6;
                        break;

                    case "B": // Paper
                        roundScore += 3;
                        break;

                    case "C": // Scissors
                        roundScore += 0;
                        break;
                    default:
                        throw new Exception("Invalid input");
                }
                break;

            case "Z": // Scissors
                roundScore += 3;
                switch (opponentPlay)
                {
                    case "A": // Rock
                        roundScore += 0;
                        break;

                    case "B": // Paper
                        roundScore += 6;
                        break;

                    case "C": // Scissors
                        roundScore += 3;
                        break;
                    default:
                        throw new Exception("Invalid input");
                }

                break;
            default:
                throw new Exception("Invalid input");
        }

        return roundScore;
    }

    static void CalculateTotalScoreByStrategy(string filename)
    {
        try
        {
            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            string[] lines = File.ReadAllLines(filename);

            int totalScore = 0;
            foreach (string line in lines)
            {
                if (line.Trim() != "")
                {
                    totalScore += CalculateRoundScoreByStrategy(line);
                }
            }

            Console.WriteLine("Total score by strategy = " + totalScore);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static int CalculateRoundScoreByStrategy(string strategy)
    {
        Dictionary<string, int> strategyToScore =
              new Dictionary<string, int>()
              {
                {"A X", 3 + 0}, // Rock vs Scissors
                {"A Y", 1 + 3}, // Rock vs Rock
                {"A Z", 2 + 6}, // Rock vs Paper
                {"B X", 1 + 0}, // Paper vs Rock
                {"B Y", 2 + 3}, // Paper vs Paper
                {"B Z", 3 + 6}, // Paper vs Scissors
                {"C X", 2 + 0}, // Scissors vs Paper
                {"C Y", 3 + 3}, // Scissors vs Scissors
                {"C Z", 1 + 6} // Scissors vs Rock
              };
        int roundScore = strategyToScore[strategy];

        return roundScore;
    }

    static void Main(string[] args)
    {
        string filename;
        if (args.Length == 0)
        {
            filename = @"c:\temp\Day2Input.txt";
        }
        else
        {
            filename = args[0];
        }
        CalculateTotalScoreByPlayerMoves(filename);
        CalculateTotalScoreByStrategy(filename);
        return;
    }

}