public class Quest
{
    public int ID;
    public string Name;
    public string Description;
    public bool IsQuestStarted = false;
    public bool IsQuestCompleted = false;

    public List<string> ListOfCompletedQuest = [];
    private int QuestCompletedCount = 0;

    public Quest(int id, string name, string description)
    {
        ID = id;
        Name = name;
        Description = description;
    }

    public void StartQuest(Location currentlocation)
    {
        if (currentlocation.ID == World.LOCATION_ID_BRIDGE ||
        currentlocation.ID == World.LOCATION_ID_FARMHOUSE ||
        currentlocation.ID == World.LOCATION_ID_ALCHEMIST_HUT
        )

        {
            Console.WriteLine($"You are at a location with a quest: '{Name}'. Do you want to start the quest? (y/n)");
            string input = Console.ReadLine()!.ToLower();

            if (input == "y")
            {
                IsQuestStarted = true;
                Console.WriteLine($"You have started the quest '{Name}': {Description}");
            }
            else if (input == "n")
            {
                Console.WriteLine("You have chosen not to start the quest.");
            }
        }
    }
    public void QuestCompleted()
    {
        if (IsQuestStarted && !IsQuestCompleted)
        {
            IsQuestCompleted = true;
            ListOfCompletedQuest.Add(Name);
            QuestCompletedCount++;

            // // reward portal stone ?
            // Random random = new Random();
            // int randomIndex = random.Next(World.Weapons.Count);
            // Weapon portal_stone = World.Weapons[randomIndex];
            // World.Weapons.RemoveAt(randomIndex);

            // // voeg beloning toe aan speler inventory
            // Program.player.Inventory.AddWeapon(portal_stone);

            Console.WriteLine($"Congratulations! You have completed the quest '{Name}'");

        }

        else if (!IsQuestStarted)
        {
            Console.WriteLine($"You cannot complete the quest '{Name}' because you have not started it yet.");
        }
    }

    public int ShowQuestCounter()
    {
        return QuestCompletedCount;
    }
}

