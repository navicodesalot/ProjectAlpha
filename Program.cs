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

        Player player = null;


        DialogueManager manager = new DialogueManager("dialogue.json");

        //  de opties van het hoofdmenu
        var options = new List<string>
        {
            "Start Game.",
            "About us.",
            "Exit game.",
            "Test Inventory.",
            "Test Dialogue."
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
                player = new Player(World.Locations[0]);
                player.CurrentLocation = World.Locations[0];
                    do
                    {
                        //compas met opties printen
                        Console.WriteLine("\nYou are X: \n" + player.CurrentLocation.Map(player.CurrentLocation));
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
                case 3: // test inventory
                    TestInventory();
                    Pause();
                    break;
                case 4: // test dialogue
                    Console.Clear();
                    Console.WriteLine("Please work.");

                    // if player no exist it still do it fuck you
                    if (player == null)
                    {
                        player = new Player(World.LocationByID(World.LOCATION_ID_ALCHEMIST_HUT));
                    }
                    player.CurrentLocation = World.LocationByID(World.LOCATION_ID_ALCHEMIST_HUT);

                    manager.ShowStartDialogue(player.CurrentLocation.ID);
                    manager.ShowCompleteDialogue(player.CurrentLocation.ID);

                    Pause();
                    break;

            }
            
            // optie om te lopen
        }
    }


    // test methode om te kijken als de inventory werkt
    // static void TestInventory()
    // {
    //     Console.WriteLine("TESTING inventory");


    //     Inventory inv = new Inventory();

    //     inv.AddWeapon(World.WeaponByID(World.WEAPON_ID_RUSTY_SWORD));
    //     inv.AddWeapon(World.WeaponByID(World.WEAPON_ID_CLUB));

    //     inv.ShowInventory();
    // }

    //=================== TEST 2 =======================
    static void TestInventory()
    {
        Player player = new Player("Wizard", 20);

        // Voeg wapens toe aan zijn inventory
        player.Inventory.AddWeapon(World.WeaponByID(World.WEAPON_ID_RUSTY_SWORD));
        player.Inventory.AddWeapon(World.WeaponByID(World.WEAPON_ID_CLUB));

        // Toon inventory
        player.Inventory.ShowInventory();

        // Maak een menu van de inventory namen
        var options = new List<string>();
        foreach (var weapon in player.Inventory.Weapons)
        {
            options.Add(weapon.Name);
        }

        var menu = new Menu("Select a weapon to equip:", options);
        int choice = menu.Show();

        // Equip dat wapen
        Weapon selected = player.Inventory.Weapons[choice];
        player.EquipWeapon(selected);
    }
    // wacht op een key zodat gebuirker output kan lezen 
    static void Pause()
    {
        Console.WriteLine("\nPress any key...");
        Console.ReadKey(true);
    }
}