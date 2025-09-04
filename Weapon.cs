/*
int ID
string Name
int MaximumDamage
*/

public static class Weapon
{
    public int ID;
    public string Name;
    public int maxDamage;

    public int minDamage;

    public Weapon(int id, string name, int minDamage, int maxDamage)
    {
        ID = id;
        Name = name;
        MinimumDamage = minDamage;
        MaximumDamage = maxDamage;
    }

}
