using System;
using System.Formats.Asn1;

class Program
{
    static void Main()
    {
        string answer;
        bool succes;
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
                    // player maken en op goede plek op de map zetten
                    Player player = new(World.Locations[0]);
                    player.CurrentLocation = World.Locations[0];
                    do
                    {
                        //compas met opties printen
                        Console.WriteLine("\nYou are X: \n"+ player.CurrentLocation.Map(player.CurrentLocation));
                        Console.WriteLine(player.CurrentLocation.Compas());
                        do
                        {
                            Console.WriteLine("Where to? (N/E/S/W)");
                            string destination = Console.ReadLine();
                            Location newLocation = player.CurrentLocation.GetLocationAt(destination.ToUpper());
                            succes = player.TryMoveTo(newLocation);
                            if (succes == false)
                            {
                                Console.WriteLine("You cannot go here.");
                            }
                        } while (succes != true);
                        Console.WriteLine($"you are now at: {player.CurrentLocation.Name}");
                        Pause();
                        do
                        {
                            Console.WriteLine("Stay here?(Y/N)");
                            answer = Console.ReadLine().ToLower();
                        } while (answer != "y" && answer != "n");
                    } while (answer == "n");
                    Console.WriteLine("There's nothing to do here... goodbye!");
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
            
            // optie om te lopen
        }
    }
    // wacht op een key zodat gebuirker output kan lezen 
    static void Pause()
    {
        Console.WriteLine("\nPress any key...");
        Console.ReadKey(true);
    }
}