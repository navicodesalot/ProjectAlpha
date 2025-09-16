/*
int ID
string Name
string Description
Quest QuestAvailableHere
Monster MonsterLivingHere
Location LocationToNorth
Location LocationToEast
Location LocationToSouth
Location LocationToWest
*/

using System.Runtime.CompilerServices;

public class Location
{
    public int ID;
    public string Name;
    public string Description;
    public Quest QuestAvailableHere;
    public Monster MonsterLivingHere;
    public Location LocationToNorth;
    public Location LocationToEast;
    public Location LocationToSouth;
    public Location LocationToWest;
    public string WorldMap;

    public Location(int id, string name, string description, Quest questavailablehere, Monster monsterlivinghere)
    {
        ID = id;
        Name = name;
        Description = description;
        QuestAvailableHere = questavailablehere;
        MonsterLivingHere = monsterlivinghere;
    }

    public string Compas()
    {
        string s = "\n\nFrom here you can go:\n";
        if (LocationToNorth != null)
        {
            s += "    N\n    |\n";
        }
        if (LocationToWest != null)
        {
            s += "W---|";
        }
        else
        {
            s += "    |";
        }
        if (LocationToEast != null)
        {
            s += "---E";
        }
        s += "\n";
        if (LocationToSouth != null)
        {
            s += "    |\n    S\n";
        }
        return s;
    }


    // supaaa niceee
    // ik ga m aanpassen zodat "X" de speler current location een andere kleur aangeeft
    // meer player friendlyyyy
    // -angel
    public void ShowMap(Location current)
    {
        string map = " P\n A\nVTGBS\n H";
        char symbol = ' ';
        if (current.Name == "Home") symbol = 'H';
        else if (current.Name == "Town square") symbol = 'T';
        else if (current.Name == "Alchemist's hut") symbol = 'A';
        else if (current.Name == "Alchemist's garden") symbol = 'P';
        else if (current.Name == "Farmhouse") symbol = 'F';
        else if (current.Name == "Farmer's field") symbol = 'V';
        else if (current.Name == "Guard post") symbol = 'G';
        else if (current.Name == "Bridge") symbol = 'B';
        else if (current.Name == "Forest") symbol = 'S';

        foreach (char c in map)
        {
            // huidige locatie
            if (c == symbol)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("X");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(c);
            }
        }
    }

    public Location GetLocationAt(string location) => location switch
    {
        "N" => LocationToNorth,
        "E" => LocationToEast,
        "S" => LocationToSouth,
        "W" => LocationToWest,
        _ => null
    };
}