using UnityEngine;

public class Hacker : MonoBehaviour
{
    enum Screen {MainMenu, Password, Win };
    int level;
    Screen currentScreen;
    string password;
    string menuHint = "You can type 'menu' whenever you want.";
    string[] passwords4L1 = { "keke", "pepe", "fefe", "lele" };
    string[] passwords4L2 = { "pepere", "kekele", "feferi", "leleri" };
    string[] passwords4L3 = { "beleperi", "duduperi", "kokonama", "sakurama", "miganasan" };



    // Start is called before the first frame update
    void Start() {
        ShowMainMenu();
    }

    void ShowMainMenu() {

        currentScreen = Screen.MainMenu;
        var greetings = "Welcome ";
        Terminal.ClearScreen();  
        Terminal.WriteLine(greetings);
        Terminal.WriteLine("");
        Terminal.WriteLine("Press 1 to hack to Apple.");
        Terminal.WriteLine("Press 2 to hack bio-dragon.");
        Terminal.WriteLine("Press 3 for Easter Egg.");
        Terminal.WriteLine("What do you want to do? ");
        
    }
    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
            currentScreen = Screen.MainMenu;
        }
        else if(input == "exit" || input == "quit" || input == "close")
        {
            Terminal.WriteLine("Quitting the game....");
            Application.Quit();
        }
        else if( currentScreen == Screen.MainMenu) 
        { 
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if(isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else
        {
            Terminal.WriteLine("Wrong input!");
            Terminal.WriteLine(menuHint);

        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password.Hint:  " + password.Anagram());
        Terminal.WriteLine(menuHint);

    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = passwords4L1[Random.Range(0, passwords4L1.Length)];
                break;
            case 2:
                password = passwords4L2[Random.Range(0, passwords4L2.Length)];
                break;
            case 3:
                password = passwords4L3[Random.Range(0, passwords4L3.Length)];
                break;
            default:
                print("Wow shoot");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
            AskForPassword();
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);

    }

    void ShowLevelReward()
    {
        switch(level)
        {
            case 1:
                Terminal.WriteLine("You are inside Apple's systems...");
                 Terminal.WriteLine(@"
      __ :'__
   .'`__`-'__``.
  :__________.-'
  :_________:
   :_________`-;
    `.__.-.__.'");
                break;
            case 2:
                Terminal.WriteLine("You found the dragon!");
                Terminal.WriteLine(@"
      . 
 .>   )\;`a__
(  _ _)/ /-.' ~~
 `( )_) /
  < _ < _ sb / dwb
        ");

                break;
            default:
                Terminal.WriteLine("You fcked up");
                break;
            case 3:
                Terminal.WriteLine("You completed the secret level!");
                break;
        }
    }
}