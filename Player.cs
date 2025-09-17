/*
string Name
int CurrentHitPoints
int MaximumHitPoints
Weapon CurrentWeapon
Location CurrentLocation
*/

using System.Runtime.CompilerServices;

public class Player
{
    public string Name;
    public int CurrentHitPoints;
    public int MaximumHitPoints;
    public Weapon CurrentWeapon;
    public Location CurrentLocation;
    public Player(Location startLocation) => CurrentLocation = startLocation;

     public List<Quest> ActiveQuests { get; private set; } = new List<Quest>();

    public bool TryMoveTo(Location newLocation)
    {
        if (newLocation == null) { return false; }

        CurrentLocation = newLocation;
        return true;
    }

    // add the player their inventory 
    public Inventory Inventory { get; private set; }

    public Player(string name, int maxHitPoints)
    {
        Name = name;
        MaximumHitPoints = maxHitPoints;
        CurrentHitPoints = maxHitPoints;
        Inventory = new Inventory();
    }

    public void EquipWeapon(Weapon weapon)
    {
        if (Inventory.Weapons.Contains(weapon))
        {
            CurrentWeapon = weapon;
            Console.WriteLine($"{Name} equipped {weapon.Name}!");
        }
        else
        {
            Console.WriteLine($"{weapon.Name} is not in your inventory.");
        }
    }

}