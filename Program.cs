using System;

class Program
{
    static void Main()
    {
        // Console.WriteLine("Press any key...");
        // Console.ReadKey(true);

        //  de opties van het hoofdmenu
        var options = new List<string>
        {
            "Start Game.",
            "About us.",
            "Exit game."
        };

        // geeft title een naam 
        var menu = new Menu("Main Menu", options);

        bool running = true;
        while (running)
        {
            //  laat het menu zien 
            int choice = menu.Show();
            Console.Clear();

            switch (choice)
            {
                // start de game
                case 0:
                    Console.WriteLine("Welcome Wizard....");
                    Pause();
                    break;

                case 1:
                    Console.WriteLine("We are the Dev group KAAS!");
                    Pause();
                    break;

                case 2:
                    Console.WriteLine("Goodbye!");
                    Pause();
                    break;
            }
        }
    }

    // wacht op een key zodat gebuirker output kan lezen 
    static void Pause()
    {
        Console.WriteLine("\nPress any key...");
        Console.ReadKey(true);
    }
}