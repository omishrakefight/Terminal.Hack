using UnityEngine;

public class Hacker : MonoBehaviour {
    const string MenuHint = "You may return to the Main Menu at any time by typing 'Menu'.";
    const string replay = "If you have more buisiness to take care of, type menu and select another one.";
    string Password = "";
    int PasswordCounter1 = 1;
    int PasswordCounter2 = 1;
    int PasswordCounter3 = 1;
    int PlayAgain;

    // Passwords
    string[] Password1 = { "bookworm", "pseudonym", "index", "author", "dictionary", "bibliography", "encyclopedia", "catalog", "librarian" };
    string[] Caps1 = { "Bookworm", "Pseudonym", "Index", "Author", "Dictionary", "Bibliography", "Encyclopedia", "Catalog", "Librarian" };

    string[] Password2 = { "sheriff", "misdemeanor", "perpetrator", "jurisdiction", "detective", "holster", "handcuffs"};
    string[] Caps2 = { "Sheriff", "Misdemeanor", "Perpetrator", "Jurisdiction", "Detective", "Holster", "Handcuffs" };

    string[] Password3 = { "astronauts", "satellite", "aliens", "telescope", "starfield", "exploration"};
    string[] Caps3 = { "Astronauts", "Satellite", "Aliens", "Telescope", "Starfield", "Exploration" };


    // Game State
    int Level;
    enum Screen { MainMenu, Password, Win};
    Screen currentScreen = Screen.MainMenu;

    string greeting = "Hello Kelsey,";

    // Use this for initialization
    void Start () {
        PlayAgain = 1;
        ShowMainMenu();
	}
	
    // Main Menu options
    void ShowMainMenu()
    {
        //Terminal.WriteLine("What is your name");
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine(greeting);
        if (PlayAgain > 1)
        {
            Terminal.WriteLine("What would you like to hack next?");
        }
        if (PlayAgain == 1)
        {
            Terminal.WriteLine("We have found a weak link in the web \ndefenses of the following locations,\n" +
                 "what would you like to hack?\n");
            ++PlayAgain;
        }

        Terminal.WriteLine("1) A library, make people return their books so you can check them out NOW.");
        Terminal.WriteLine("2) A police station, double check your friends date. Blackmail is fun.");
        Terminal.WriteLine("3) The NASA. Because you always wanted to. We have all wanted to.");
    }

    void OnUserInput(string input)
    {
        
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            if (Level == 1)
            {
                RunPasswordOne(input);
            }
            if (Level == 2)
            {
                RunPasswordTwo(input);
            }
            if (Level == 3)
            {
                RunPasswordThree(input);
            }
        }
    }
    // First set of passwords
    void RunPasswordOne(string input)
    {
        
        if (input == Password1[PasswordCounter1] || input == Caps1[PasswordCounter1])
            {
                 ShowLevelReward();
            }
        else
            {
                Terminal.ClearScreen();
                Terminal.WriteLine("Wrong password, please try again. \n\n" + Password.Anagram());
            }
    }
    // Second set of passwords
    void RunPasswordTwo(string input)
    {
        if (input == Password2[PasswordCounter2] || input == Caps2[PasswordCounter2])
            {
            ShowLevelReward();
            }
        else
            {
            Terminal.ClearScreen();
            Terminal.WriteLine("Wrong password, please try again. \n\n" + Password.Anagram());
            }
    }
    // Third set of passwords
    void RunPasswordThree(string input)
    {
        if (input == Password3[PasswordCounter3] || input == Caps3[PasswordCounter3])
            {
            ShowLevelReward();
            }
        else
            {
            Terminal.ClearScreen();
            Terminal.WriteLine("Wrong password, please try again. \n\n" + Password.Anagram());
            }  
    }


    
        void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            Level = int.Parse(input);
            StartGame(Level);
        }
        else if (input == "007")
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("You grace this humble machine, Mr Bond.  I would be honored to assisst in your Hacking.");
        }
        else
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("Please choose a valid selection \n" + MenuHint);
        }
    }

    void StartGame(int level)
    {
        Terminal.ClearScreen();
        currentScreen = Screen.Password;

        // show password set for 1
        if (Level == 1)
        {
            PasswordCounter1 = Random.Range(0, Password1.Length);
            Password = Password1[PasswordCounter1];
            Terminal.WriteLine(MenuHint + "\nInsert password.  HINT : " + Password.Anagram());
        }

        // show password set for 2
        else if (Level == 2)
        {
            PasswordCounter2 = Random.Range(0, Password2.Length);
            Password = Password2[PasswordCounter2];
            Terminal.WriteLine(MenuHint + "\nInsert password.  HINT :  " + Password.Anagram());
        }

        // show password set for 3
        else if (Level == 3)
        {
            PasswordCounter3 = Random.Range(0, Password3.Length);
            Password = Password3[PasswordCounter3];
            Terminal.WriteLine(MenuHint + "\nInsert password.  HINT : " + Password.Anagram());
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();

    }

    void ShowLevelReward()
    {
        switch (Level)
        {
            case 1:
                Terminal.ClearScreen();
                Terminal.WriteLine("\nWelcome, Gerald.  What book do you need returned?" + @"
     _________
    /  ... / /
   / .... / /
  / ...  / /
 /      / /
(______/_/"
 + replay       );
                break;
            case 2:
                Terminal.ClearScreen();
                Terminal.WriteLine("\nWelcome, detective.  Looking up the file now..." + @"

------------|\
|  Profile  | \
|    of     | |
|Jhon Doe...| |
|___________|_|
 \__________\_|
 " + replay     );
                break;
            case 3:
                Terminal.ClearScreen();
                Terminal.WriteLine("\nWelcome, Mr Smrtypnts.  An update about the test tubes are ready . . ." +
                " \n. \n." + @"
        |\  || /\
__  __    \\//  |
||  ||     | /     THE ALIEN ESCAPED!
||  ||     ||
\/  \/     \/
" + replay      );
                break;
        }
        
    }
}


