/*
string Name
int CurrentHitPoints
int MaximumHitPoints
Weapon CurrentWeapon
Location CurrentLocation
*/

public class Player
{
    public string Name;
    public int CurrentHitPoints;
    public int MaximumHitPoints;
    public Weapon CurrentWeapon;
    public Location CurrentLocation;
    public Player(Location startLocation) => CurrentLocation = startLocation;

    public bool TryMoveTo(Location newLocation)
    {
        if (newLocation == null) { return false; }

        CurrentLocation = newLocation;
        return true;
    }
}