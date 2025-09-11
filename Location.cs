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
        string s = "\nFrom here you can go:\n";
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

    public string Map(Location current)
    {
        WorldMap = " P\n A\nVTGBS\n H";
        if (current.Name == "Home")
        {
            WorldMap = WorldMap.Replace("H", "X");
        }
        else if (current.Name == "Town square")
        {
            WorldMap = WorldMap.Replace("T", "X");
        }
        else if (current.Name == "Alchemist's hut")
        {
            WorldMap = WorldMap.Replace("A", "X");
        }
        else if (current.Name == "Alchemist's garden")
        {
            WorldMap = WorldMap.Replace("P", "X");
        }
        else if (current.Name == "Farmhouse")
        {
            WorldMap = WorldMap.Replace("F", "X");
        }
        else if (current.Name == "Farmer's field")
        {
            WorldMap = WorldMap.Replace("V", "X");
        }
        else if (current.Name == "Guard post")
        {
            WorldMap = WorldMap.Replace("G", "X");
        }
        else if (current.Name == "Bridge")
        {
            WorldMap = WorldMap.Replace("B", "X");
        }
        else if (current.Name == "Forest")
        {
            WorldMap = WorldMap.Replace("S", "X");
        }
        return WorldMap;
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