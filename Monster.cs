/*
int ID
string Name
int MaximumDamage
int CurrentHitPoints
int MaximumHitPoints
*/

public class Monster
{
    public int ID;
    public string Name;
    public int MaximumDamage;
    public int CurrentHitPoints;
    public int MaximumHitPoints;

    public Monster(int id, string name, int maxDamage, int currentHp, int maxHp)
    {
        ID = id;
        Name = name;
        MaximumDamage = maxDamage;
        CurrentHitPoints = currentHp;
        MaximumHitPoints = maxHp;
    }
}

