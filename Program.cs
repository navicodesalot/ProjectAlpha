using System;
using System.Data;
using System.Formats.Asn1;
using System.Collections.Generic;
using System.Threading;
using System.Formats.Tar;

class Program
{
    static void Main()
    {
        Player player = null;
        DialogueManager manager = new DialogueManager("dialogue.json");

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
            // Console.Clear();

            switch (choice)
            {
                case 0:
                // welkom de speler
                    Console.WriteLine("Welcome Wizard....");
                    player = new Player(World.Locations[0]);
                    player.CurrentLocation = World.Locations[0];

                    bool keepExploring = true;
                    do
                    {

                        Console.Clear();
                        Console.WriteLine("=== Current Location ===");
                        Console.WriteLine($"You're at {player.CurrentLocation.Name}");
                        Console.WriteLine(player.CurrentLocation.Description);
                        // toon de compas en de map voordat de gebruiker een keus kan maken
                        Console.WriteLine("\nYou are X: ");
                        player.CurrentLocation.ShowMap(player.CurrentLocation);
                        Console.WriteLine(player.CurrentLocation.Compas());
                        Pause();

                        // maak een lift aan met de opties die beschikbaar zijn om naar te navigeren 
                        // dit is de lijst waar de nieuwe opties in komt
                        List<string> moveOptions = new List<string>();
                        // dit zijn de opties die in de lijst komt. 
                        if (player.CurrentLocation.LocationToNorth != null) moveOptions.Add("North");
                        if (player.CurrentLocation.LocationToEast != null) moveOptions.Add("East");
                        if (player.CurrentLocation.LocationToSouth != null) moveOptions.Add("South");
                        if (player.CurrentLocation.LocationToWest != null) moveOptions.Add("West");


                        //------->// DEBUGGGGGG 
                        // Zorg dat de speler altijd een "niet bewegen" of "exit" optie heeft.
                        // Zo wordt menu nooit leeg en komt er altijd een keuzescherm.
                        moveOptions.Add("Stay here");
                        moveOptions.Add("Exit to the main menu");
                        // dan skipt hij alle dialoog naar hier
                        // menu tonen 
                        var moveMenu = new Menu("Where do you want to go?", moveOptions);
                        int moveChoice = moveMenu.Show();

                        Location newLocation = null;
                        switch (moveOptions[moveChoice])
                        {
                            case "North":
                                newLocation = player.CurrentLocation.LocationToNorth;
                                break;
                            case "East":
                                newLocation = player.CurrentLocation.LocationToEast;
                                break;
                            case "South":
                                newLocation = player.CurrentLocation.LocationToSouth;
                                break;
                            case "West":
                                newLocation = player.CurrentLocation.LocationToWest;
                                break;
                            case "Stay here":
                                if(player.CurrentLocation.QuestAvailableHere != null && 
                                   !player.CurrentLocation.QuestAvailableHere.IsQuestCompleted)
                                {
                                    player.CurrentLocation.QuestAvailableHere.StartQuest(player.CurrentLocation);
                                    if(player.CurrentLocation.QuestAvailableHere.IsQuestStarted)
                                    {
                                        Combat.StartCombat(player, player.CurrentLocation.MonsterLivingHere, player.CurrentWeapon);
                                        player.CurrentLocation.QuestAvailableHere.QuestCompleted();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Nothing to do here...");
                                    Pause();
                                }
                                break;
                            case "Exit to main menu":
                                keepExploring = false;
                                break;
                        }

                        if (newLocation != null)
                        {
                            bool succes = player.TryMoveTo(newLocation);
                            if (!succes)
                            {
                                Console.WriteLine("You cannot go there!");
                            }
                            else
                            {
                                Console.WriteLine($"You are now at {player.CurrentLocation.Name}");
                                Console.WriteLine("\nYou are X: ");
                                player.CurrentLocation.ShowMap(player.CurrentLocation);
                                Console.WriteLine(player.CurrentLocation.Compas());
                            }
                            Pause();
                        }
                    }
                    while (keepExploring);
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
                        // TestInventory();]
                    Console.Clear();
                    Console.WriteLine("Please work.");
                    
                    // Pause();
                    // break;
                // case 4: // test dialogue
                    

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
    // static void TestInventory()
    // {
    //     Player player = new Player("Wizard", 20);

    //     // Voeg wapens toe aan zijn inventory
    //     player.Inventory.AddWeapon(World.WeaponByID(World.WEAPON_ID_RUSTY_SWORD));
    //     player.Inventory.AddWeapon(World.WeaponByID(World.WEAPON_ID_CLUB));

    //     // Toon inventory
    //     player.Inventory.ShowInventory();

    //     // Maak een menu van de inventory namen
    //     var options = new List<string>();
    //     foreach (var weapon in player.Inventory.Weapons)
    //     {
    //         options.Add(weapon.Name);
    //     }

    //     var menu = new Menu("Select a weapon to equip:", options);
    //     int choice = menu.Show();

    //     // Equip dat wapen
    //     Weapon selected = player.Inventory.Weapons[choice];
    //     player.EquipWeapon(selected);
    // }
    // wacht op een key zodat gebuirker output kan lezen 
    static void Pause()
    {
        Console.WriteLine("\nPress any key...");
        Console.ReadKey(true);
    }
}