/*
int ID
string Name
int MaximumDamage
int MinimumDamage
*/

public class Weapon
{
    public int ID;
    public string Name;
    public int MaximumDamage;
    public int MinimumDamage;

    public Weapon(int id, string name, int minDamage, int maxDamage)
    {
        ID = id;
        Name = name;
        MinimumDamage = minDamage;
        MaximumDamage = maxDamage;
    }


    
}