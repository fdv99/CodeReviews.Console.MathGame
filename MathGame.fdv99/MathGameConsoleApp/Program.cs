using System;

internal class Program
{
    private static void Main(string[] args)
    {
        List<string> scores = new List<string>();
        while (true)
        {
            Console.WriteLine("Welcome to the Math Game. Enter a number below to get started.");
            int option = MenuOptions();
            Console.Clear();
            Console.WriteLine($"You chose option {option}, lets get started!");

            // Switch Statement
            switch (option)
            {
                case 1:
                    //Call Addition Method
                    scores.Add(Addition());
                    break;
                case 2:
                    scores.Add(Subtraction());
                    //Call Subtraction Method
                    break;
                case 3:
                    scores.Add(Multiplication());
                    break;
                case 4:
                    scores.Add(Division());
                    break;
                case 5:
                    PrintScores(scores);
                    break;
                case 6:
                    QuitGame();
                    break;
            }
            Console.WriteLine("------------------");
        }

    }

    public static string Addition()
    {
        Console.WriteLine("What is your name: ");
        string name = Console.ReadLine();
        GameOptions(out int difficulty, out int problems);
        int rightAnswers = 0;

        for (int i = 0; i < problems; i++)
        {
            RandomNumbers(difficulty, out int x, out int y);

            Console.WriteLine($"{x} + {y} = ");
            int input = int.Parse(Console.ReadLine());
            int answer = x + y;
            AnswerCheck(input, answer, out bool isCorrect);
            if (isCorrect == true)
            {
                rightAnswers++;
            }
        }

        string score = Grade(rightAnswers, problems, name);
        return score;
    }

    public static string Subtraction()
    {
        Console.WriteLine("What is your name: ");
        string name = Console.ReadLine();
        GameOptions(out int difficulty, out int problems);
        int rightAnswers = 0;

        for (int i = 0; i < problems; i++)
        {
            int input = 0;
            int answer = 0;
            RandomNumbers(difficulty, out int x, out int y);

            if (x >= y)
            {
                answer = x - y;

                Console.WriteLine($"{x} - {y} = ");
                input = int.Parse(Console.ReadLine());
            }
            else if (y > x)
            {
                answer = y - x;
                Console.WriteLine($"{y} - {x} = ");
                input = int.Parse(Console.ReadLine());
            }

            AnswerCheck(input, answer, out bool isCorrect);
            if (isCorrect == true)
            {
                rightAnswers++;
            }
            else
            {
                Console.WriteLine("Wrong.");
            }
        }

        string score = Grade(rightAnswers, problems, name);
        return score;
    }

    public static string Multiplication()
    {
        Console.WriteLine("What is your name: ");
        string name = Console.ReadLine();
        GameOptions(out int difficulty, out int problems);
        int rightAnswers = 0;

        for (int i = 0; i < problems; i++)
        {
            RandomNumbers(difficulty, out int x, out int y);

            Console.WriteLine($"{x} * {y} = ");
            int input = int.Parse(Console.ReadLine());
            int answer = x * y;
            AnswerCheck(input, answer, out bool isCorrect);
            if (isCorrect == true)
            {
                rightAnswers++;
            }
        }

        string score = Grade(rightAnswers, problems, name);
        return score;
    }

    public static string Division()
    {
        Console.WriteLine("What is your name: ");
        string name = Console.ReadLine();
        GameOptions(out int difficulty, out int problems);
        int rightAnswers = 0;

        for (int i = 0; i < problems; i++)
        {
            int x, y, answer;
            do
            {
                // Generate numbers within the desired range and ensure they aren't zero
                RandomNumbers(difficulty, out x, out y);

                // Ensure x and y are both non-zero
                if (x == 0 || y == 0) continue;

                // Swap x and y if needed to ensure x is always greater than y
                if (x < y)
                {
                    int temp = x;
                    x = y;
                    y = temp;
                }

            } while (x % y != 0);  // Repeat until we get an integer result

            // Now we have an integer division
            answer = x / y;

            Console.WriteLine($"{x} / {y} = ");
            int input = int.Parse(Console.ReadLine());

            AnswerCheck(input, answer, out bool isCorrect);
            if (isCorrect)
            {
                rightAnswers++;
            }
        }

        string score = Grade(rightAnswers, problems, name);
        return score;
    }

    // Provide the random numbers for each method.  Difficulty is the max number it will generate
    public static void RandomNumbers(int difficulty, out int x, out int y)
    {
        Random rnd = new Random();
        x = rnd.Next(difficulty);
        y = rnd.Next(difficulty);
    }

    // Provide the score at the end of each round
    public static string Grade(int rightAnswers, int problems, string name)
    {
        double grade = (Convert.ToDouble(rightAnswers) / Convert.ToDouble(problems)) * 100;
        Console.WriteLine($"You scored: {grade}%");
        string score = $"{grade} : {name}";
        return score;
    }

    // Check the answer and display the prompt for the result
    public static void AnswerCheck(int input, int answer, out bool isCorrect)
    {
        isCorrect = false;
        if (input == answer)
        {
            Console.WriteLine("Correct!");
            isCorrect = true;
        }
        else
        {
            Console.WriteLine("Wrong.");
        }

    }

    // Print the list of scores after each round in descending order
    public static void PrintScores(List<string> scores)
    {
        // Sort the scores by the numeric value in descending order
        var sortedScores = scores
            .OrderByDescending(s => double.Parse(s.Split(':')[0].Trim()))
            .ToList();

        // Print each score
        Console.Clear();
        Console.WriteLine("****************");
        foreach (string score in sortedScores)
        {
            Console.WriteLine(score);
        }
        Console.WriteLine("****************");
    }

    public static void GameOptions(out int difficulty, out int problems)
    {
        difficulty = 10; // Default, easy
        Console.WriteLine("Select a difficulty level (10-100): ");
        bool isValid = int.TryParse(Console.ReadLine(), out difficulty);

        problems = 10; // Default
        Console.WriteLine("Select the number of problems to attempt (Default 10): ");
        bool isValidProblem = int.TryParse(Console.ReadLine(), out problems);

        if (isValidProblem == false || isValid == false)
        {
            Console.WriteLine("Input not Valid, we will use defaults for this game");
        }
    }

    public static int MenuOptions()
    {
        bool selectionMade = false;
        string optionSelection = null;
        int optionSelectionInt = 0;

        while (selectionMade == false)
        {
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. View Game History");
            Console.WriteLine("6. Quit");

            optionSelection = Console.ReadLine();

            bool isValidInt = int.TryParse(optionSelection, out optionSelectionInt);
            bool isValidEntry = optionSelectionInt < 7 && optionSelectionInt > 0;
            if (isValidEntry == true && isValidInt == true)
            {
                selectionMade = true;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please enter a valid number: ");
                Console.WriteLine("-----------------------------------------");
            }
        }

        return optionSelectionInt;
    }

    public static void QuitGame()
    {
        Environment.Exit(0);
    }
}