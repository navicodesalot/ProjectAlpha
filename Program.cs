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
            "Exit game.",
            "Test Inventory."
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
                case 3: // test inventory
                    TestInventory();
                    Pause();
                    break;

            }
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