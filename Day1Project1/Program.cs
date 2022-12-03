class Program
{
    static void CalculateMostCalories(string filename)
    {
        try
        {
            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            string[] lines = File.ReadAllLines(filename);

            long mostCalories = 0;
            long currentCalories = 0;
            foreach (string line in lines)
            {
                // we have reached the end of a particular elf
                if (line.Trim() == "")
                {
                    if (currentCalories > mostCalories)
                    {
                        mostCalories = currentCalories;
                    }
                    currentCalories = 0;
                }
                else
                {
                    long calories = long.Parse(line.Trim());

                    currentCalories += calories;
                }
            }

            Console.WriteLine("Most calories = " + mostCalories);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void CalculateTopMostCalories(string filename, int numRanks)
    {
        try
        {
            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            string[] lines = File.ReadAllLines(filename);

            long[] mostCalories = new long[numRanks];
            // initialize array to 0
            for (int i = 0; i < numRanks; i++)
            {
                mostCalories[i] = 0;
            }

            long currentCalories = 0;
            foreach (string line in lines)
            {
                // we have reached the end of a particular elf
                if (line.Trim() == "")
                {
                    UpdateRankings(mostCalories, currentCalories);
                    currentCalories = 0;
                }
                else
                {
                    long calories = long.Parse(line.Trim());

                    currentCalories += calories;
                }
            }

            long totalCalories = 0;
            Console.WriteLine("Most calories = " + mostCalories);
            for (int i = 0; i < mostCalories.Length; i++)
            {
                Console.WriteLine(mostCalories[i]);
                totalCalories += mostCalories[i];
            }
            Console.WriteLine("Total calories = " + totalCalories);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void UpdateRankings(long[] mostCalories, long currentCalories)
    {
        for (int i = 0; i < mostCalories.Length; i++)
        {
            // find position and insert
            if (currentCalories > mostCalories[i])
            {
                InsertInArray(mostCalories, currentCalories, i);
                break;
            }
        }
    }

    static void InsertInArray(long[] longArray, long newItem, int insertAtIndex)
    {
        // loop from bottom up to position to insert
        for (int i = longArray.Length - 1; i > insertAtIndex; i--)
        {
            longArray[i] = longArray[i - 1];
        }
        longArray[insertAtIndex] = newItem;
    }

    static void Main(string[] args)
    {
        string filename;
        if (args.Length == 0)
        {
            filename = @"c:\temp\Day1Project1Input.txt";
        }
        else
        {
            filename = args[0];
        }
        CalculateMostCalories(filename);
        CalculateTopMostCalories(filename, 3);
        return;
    }

}