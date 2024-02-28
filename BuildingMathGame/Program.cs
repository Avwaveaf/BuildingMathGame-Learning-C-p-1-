using static System.Formats.Asn1.AsnWriter;

DateTime dateTime = DateTime.Now;

DateTime date = DateTime.UtcNow;

DateTime endGameAt;

List<string> gmHistory = new List<string>();


// @TODO bikin angka pertama lebih daripada kedua
// @TODO Bikin level difficulty



string name = GetName();

Menu(name);

    
void Menu(string name)

{
    
    dateTime = DateTime.Now;
    bool gameOn = true;


    do {

        Console.Clear();
        Console.WriteLine("===================================");
        Console.WriteLine($"Welcome {name} today is {date}");
        Console.Write($@"
    Select Menu Below:

    0  - Arithmetic Mode

    A  - Addition
    S  - Substraction
    M  - Multiplication
    D  - Division
    
    -----------------------------------------
    L  - Leaderboards
    E  - Exit game
");

        Console.WriteLine("===================================");
        Console.Write("(You) :");
        String choice = Console.ReadLine();


        switch (choice.Trim().ToLower())
        {
            case "0":
                ArithmeticGame();
                break;
            case "a":
                AdditionGame("Addition game Started");
                break;
            case "s":
                SubstractionGame("Substraction game Started");
                break;
            case "m":
                MultiplicationGame("Multiplication game Started");
                break;
            case "d":
                DivisionGame("Division game Started");
                break;
            case "l":
                ShowLeaderboards();
                break;
            case "e":
                Console.WriteLine("See yaa...");
                gameOn = false;
                Environment.Exit(1);
                break;

            default:
                Console.WriteLine("Invalid Input!");
                break;
        }

    } while (gameOn);


}


    
static string GetName()
{
    Console.WriteLine("Please Enter your name");
    string name = Console.ReadLine();
    return name;
}



int[] GetDivisionNumber() {
    Random rand = new Random();
    int fNum = rand.Next(1, 99);
    int sNum = rand.Next(1, 99);

    var result = new int[2];

    while (fNum == 0 || sNum == 0 || fNum % sNum != 0) {
        // Keep generate as long the fnum and snum cannot be divided equally
        fNum = rand.Next(0, 99);
        sNum = rand.Next(0, 99);
    }

    result[0] = fNum;
    result[1] = sNum;

    return result;

}

void ArithmeticGame()
{
    int score = 0;
    Console.Clear();
    Console.WriteLine($"Current Score : {score}\n");

    for (int i = 0; i < 10; i++)
    {
        Random rnd = new Random();
        // 0: addition 1:Substraction 2:Multiplication 3:Division
        int dice = rnd.Next(0, 4);
        int num = rnd.Next(0, 15);
        int denum = rnd.Next(0, 15);

        switch (dice)
        {
            case 0:
                // Clear the console every new game
                Console.Clear();

                Console.WriteLine($"Current Score : {score}\n");
                Console.WriteLine($"Solve this equation #{i + 1}! \n {num}+{denum} = ?");
                Console.Write("Your answer :");
                string a = Console.ReadLine();

                while (string.IsNullOrWhiteSpace(a))
                {
                    Console.WriteLine("Invalid input! Please enter a valid number.");
                    Console.WriteLine("Your answer:");
                    a = Console.ReadLine();
                }

                if (Convert.ToInt32(a) == num + denum)
                {
                    score++;
                    Console.WriteLine("Correct!!\n");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();

                }
                else
                {

                    Console.WriteLine("\nIncorrect :(\n ");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();

                }

                break;

            case 1:
                // Clear the console every new game
                Console.Clear();

                Console.WriteLine($"Current Score : {score}\n");
                Console.WriteLine($"Solve this equation #{i + 1}! \n {num}-{denum} = ?");
                Console.Write("Your answer :");
                string b = Console.ReadLine();

                while (string.IsNullOrWhiteSpace(b))
                {
                    Console.WriteLine("Invalid input! Please enter a valid number.");
                    Console.WriteLine("Your answer:");
                    a = Console.ReadLine();
                }

                if (Convert.ToInt32(b) == num - denum)
                {
                    score++;
                    Console.WriteLine("Correct!!\n");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();

                }
                else
                {

                    Console.WriteLine("\nIncorrect :( ");

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();

                }
                break;


            case 2:
                // Clear the console every new game
                Console.Clear();

                Console.WriteLine($"Current Score : {score}\n");
                Console.WriteLine($"Solve this equation #{i + 1}! \n {num}*{denum} = ?");
                Console.Write("Your answer :");
                string c = Console.ReadLine();

                while (string.IsNullOrWhiteSpace(c))
                {
                    Console.WriteLine("Invalid input! Please enter a valid number.");
                    Console.WriteLine("Your answer:");
                    c = Console.ReadLine();
                }

                if (Convert.ToInt32(c) == num * denum)
                {
                    score++;
                    Console.WriteLine("Correct!!\n");

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                }
                else
                {

                    Console.WriteLine("\nIncorrect :( ");

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();

                }

                break;
            case 3:
                // Clear the console every new game
                Console.Clear();

                Console.WriteLine($"Current Score : {score}\n");

                // Get 2 random number (base, end)
                int[] divisionNum = GetDivisionNumber();
                int numDiv = divisionNum[0];
                int denumDiv = divisionNum[1];

                Console.WriteLine($"Solve this equation #{i + 1}! \n {numDiv}/{denumDiv} = ?");
                Console.Write("Your answer :");
                string res = Console.ReadLine();

                while (string.IsNullOrWhiteSpace(res))
                {
                    Console.WriteLine("Invalid input! Please enter a valid number.");
                    Console.WriteLine("Your answer:");
                    res = Console.ReadLine();
                }

                if (Convert.ToInt32(res) == numDiv / denumDiv)
                {
                    score++;
                    Console.WriteLine("Correct!!\n");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                }
                else
                {

                    Console.WriteLine("\nIncorrect :( ");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();

                }

                break;
            default:
                Console.WriteLine("invalid input");
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
                break;
        }
        Console.WriteLine($"Your final score: {score}");


    }
    // get the time when user lose or win
    endGameAt = DateTime.Now;
    string a_duration = GetGameDuration(dateTime, endGameAt);

    // save the game history
    SaveToLeaderboards(endGameAt, gmHistory,"Arithmetic", name, score, a_duration);

    Console.WriteLine(a_duration);

    Console.WriteLine("Try Again ? (Y/N)");
    Console.Write("answer: ");
    string a_ans = Console.ReadLine().Trim().ToUpper();

    if (a_ans == "Y")
    {
        dateTime = DateTime.Now;
        // Recall the game
        ArithmeticGame();
    }
    else
    {
        // call the menu
        Menu(name);
    }

}

void DivisionGame(string msg)
{
    Console.WriteLine(msg);
    int score = 0;

    Random rnd = new Random();

    for (int i = 0; i < 5; i++)
    {
        // Clear the console every new game
        Console.Clear();

        Console.WriteLine($"Current Score : {score}\n");

        // Get 2 random number (base, end)
        int[] divisionNum = GetDivisionNumber();
        int num = divisionNum[0];
        int denum = divisionNum[1];


        Console.WriteLine($"Solve this equation #{i + 1}! \n {num}/{denum} = ?");
        Console.Write("Your answer :");
        string res = Console.ReadLine();

        if (Convert.ToInt32(res) == num / denum)
        {
            score++;
            Console.WriteLine("Correct!!\n");
        }
        else
        {

            Console.WriteLine("\nIncorrect :( ");
            Console.WriteLine("GAME OVER \n");
            break;
        }
    }

    // get the time when user lose or win
    endGameAt = DateTime.Now;
    string duration = GetGameDuration(dateTime, endGameAt);

    // saving game log to leaderboards
    SaveToLeaderboards(endGameAt, gmHistory, "Division", name, score, duration);

    Console.WriteLine(duration);

    Console.WriteLine("Try Again ? (Y/N)");
    Console.Write("answer: ");
    string ans = Console.ReadLine().Trim().ToUpper();

    if (ans == "Y")
    {
        dateTime = DateTime.Now;
        // Recall the game
        DivisionGame("");
    }
    else
    {
        // call the menu
        Menu(name);
    }


}

void MultiplicationGame(string v)
{
    Console.WriteLine(v);
    int score = 0;

    Random rnd = new Random();

    for (int i = 0; i < 5; i++)
    {
        // Clear the console every new game
        Console.Clear();

        Console.WriteLine($"Current Score : {score}\n");

        // Get 2 random number (base, end)
        int num = rnd.Next(0, 15);
        int denum = rnd.Next(0, 15);


        Console.WriteLine($"Solve this equation #{i + 1}! \n {num}*{denum} = ?");
        Console.Write("Your answer :");
        string res = Console.ReadLine();

        if (Convert.ToInt32(res) == num * denum)
        {
            score++;
            Console.WriteLine("Correct!!\n");
        }
        else
        {

            Console.WriteLine("\nIncorrect :( ");
            Console.WriteLine("GAME OVER \n");
            break;
        }
    }

    // get the time when user lose or win
     endGameAt = DateTime.Now;
    string duration = GetGameDuration(dateTime, endGameAt);


    // saving game log to leaderboards
    SaveToLeaderboards(endGameAt, gmHistory, "Multiplication", name, score, duration);

    Console.WriteLine(duration);

    Console.WriteLine("Try Again ? (Y/N)");
    Console.Write("answer: ");
    string ans = Console.ReadLine().Trim().ToUpper();

    if (ans == "Y")
    {
        dateTime = DateTime.Now;
        // Recall the game
        MultiplicationGame("");
    }
    else
    {
        // call the menu
        Menu(name);
    }


}


void SubstractionGame(string v)
{
    Console.WriteLine(v);
    int score = 0;

    Random rnd = new Random();

    for (int i = 0; i < 5; i++)
    {
        // Clear the console every new game
        Console.Clear();

        Console.WriteLine($"Current Score : {score}\n");

        // Get 2 random number (base, end)
        int num = rnd.Next(0, 15);
        int denum = rnd.Next(0, 15);


        Console.WriteLine($"Solve this equation #{i + 1}! \n {num}-{denum} = ?");
        Console.Write("Your answer :");
        string res = Console.ReadLine();

        if (Convert.ToInt32(res) == num - denum)
        {
            score++;
            Console.WriteLine("Correct!!\n");
        }
        else
        {

            Console.WriteLine("\nIncorrect :( ");
            Console.WriteLine("GAME OVER \n");
            break;
        }
    }

    // get the time when user lose or win
     endGameAt = DateTime.Now;
    string duration = GetGameDuration(dateTime, endGameAt);


    // saving game log to leaderboards
    SaveToLeaderboards(endGameAt, gmHistory, "Substraction", name, score, duration);

    Console.WriteLine(duration);

    Console.WriteLine("Try Again ? (Y/N)");
    Console.Write("answer: ");
    string ans = Console.ReadLine().Trim().ToUpper();

    if (ans == "Y")
    {
        // reset the time
        dateTime = DateTime.Now;
        // Recall the game
        SubstractionGame("");
    }
    else
    {
        // call the menu
        Menu(name);
    }


}

void AdditionGame(string v)
{
    Console.WriteLine(v);
    int score = 0;

    Random rnd = new Random();

    for (int i = 0; i < 5; i++)
    {
        // Clear the console every new game
        Console.Clear();

        Console.WriteLine($"Current Score : {score}\n");

        // Get 2 random number (base, end)
        int num = rnd.Next(0, 15);
        int denum = rnd.Next(0, 15);


        Console.WriteLine($"Solve this equation #{i + 1}! \n {num}+{denum} = ?");
        Console.Write("Your answer :");
        string res = Console.ReadLine();

        if (Convert.ToInt32(res) == num + denum)
        {
            score++;
            Console.WriteLine("Correct!!\n");
        }
        else
        {

            Console.WriteLine("\nIncorrect :( ");
            Console.WriteLine("GAME OVER \n");
            break;
        }
    }

    // get the time when user lose or win
    endGameAt = DateTime.Now;
    string duration = GetGameDuration(dateTime, endGameAt);


    // saving game log to leaderboards
    SaveToLeaderboards(endGameAt, gmHistory, "Addition", name, score, duration);

    Console.WriteLine(duration);

    Console.WriteLine("Try Again ? (Y/N)");
    Console.Write("answer: ");
    string ans = Console.ReadLine().Trim().ToUpper();

    if (ans == "Y")
    {
        dateTime = DateTime.Now;
        // Recall the game
        AdditionGame("");
    }
    else
    {
        // call the menu
        Menu(name);
    }


}


 string GetGameDuration(DateTime dateTime, DateTime endGameAt)
{
    // Calculate time difference in TimeSpan
    TimeSpan diff = endGameAt - dateTime;

    // Get individual components (hours, minutes, seconds)
    int hours = diff.Hours;
    int minutes = diff.Minutes % 60; // Get remainder after dividing by 60 for minutes
    double seconds = diff.Seconds + diff.Milliseconds / 1000.0; // Include milliseconds for fractional seconds

    // Build the formatted string considering each component
    string formattedTime = "";
    if (hours > 0)
    {
        formattedTime += $"{hours} hours";
    }
    if (hours > 0 || minutes > 0)
    {
        formattedTime += $"{minutes:00} minutes"; // Pad minutes with leading 0 if needed
    }
    formattedTime += $"{seconds:0.0} seconds"; // Display seconds with one decimal place

   

    return $"Game took: {formattedTime}";
}

 void ShowLeaderboards()
{
    Console.Clear();
    Console.WriteLine($@"
    ======================================================
                        LEADERBOARDS
    ======================================================
    ");

    if (gmHistory.Count != 0)
    {

        foreach (var item in gmHistory)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("\nPress anything to continue...");
        Console.ReadLine();
    }
    else {

        Console.WriteLine("No Results!");
        Console.WriteLine("\nPress anything to continue...");
        Console.ReadLine();
    }

}

static void SaveToLeaderboards(DateTime endGameAt, List<string> gmHistory,string gameType, string name, int score, string a_duration)
{
    // record game duration data
    gmHistory.Add($"{endGameAt} \t  score : {score}  \t game-type: {gameType}  \t  username: {name} \t  {a_duration}");
}