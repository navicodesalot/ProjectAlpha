public class Quest
{
    public int ID;
    public string Name;
    public string Description;
    public bool IsQuestStarted = false;
    public bool IsQuestCompleted = false;

    private int QuestCompletedCount = 0;

    public Quest(int id, string name, string description)
    {
        ID = id;
        Name = name;
        Description = description;
    }

    public void StartQuest(Player player, Location currentlocation)
    {
        if (IsQuestStarted)
        {
            Console.WriteLine($"The quest '{Name} has already been started'");
            return;
        }
        if (currentlocation.ID == World.LOCATION_ID_BRIDGE ||
            currentlocation.ID == World.LOCATION_ID_FARMHOUSE ||
            currentlocation.ID == World.LOCATION_ID_ALCHEMIST_HUT
            )

            do
            {
                Console.WriteLine($"You are at a location with a quest: '{Name}'. Do you want to start the quest? (y/n)");
                string input = Console.ReadLine()!.ToLower();

                if (input == "y")
                {
                    IsQuestStarted = true;
                    Console.WriteLine($"You have started the quest '{Name}': {Description}");
                    player.ActiveQuests.Add(this);
                    break;
                }
                else if (input == "n")
                {
                    Console.WriteLine("You have chosen not to start the quest.");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                }
            } while (true);
            

        }
    
    public void QuestCompleted()
    {
        if (IsQuestStarted && !IsQuestCompleted)
        {
            IsQuestCompleted = true;
            foreach (var quest in World.Quests)
            {
                if (quest.IsQuestCompleted)
                {
                    QuestCompletedCount++;
                }
            }
            // // reward portal stone ?
            // Random random = new Random();
            // int randomIndex = random.Next(World.Weapons.Count);
            // Weapon portal_stone = World.Weapons[randomIndex];
            // World.Weapons.RemoveAt(randomIndex);

            // // voeg beloning toe aan speler inventory
            // Program.player.Inventory.AddWeapon(portal_stone);

            Console.WriteLine($"Congratulations! You have completed the quest '{Name}'");
            Console.WriteLine($"Quest Completed: '{QuestCompletedCount}'");

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

