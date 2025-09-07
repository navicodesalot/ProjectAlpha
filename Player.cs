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
    Weapon CurrentWeapon;

    public Player(string name, int maxHp, int currentHp, Weapon weapon)
{
    Name = name;
    MaximumHitPoints = maxHp;
    CurrentHitPoints = currentHp;
    CurrentWeapon = weapon;
}


}