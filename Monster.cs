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
    public int MinimumDamage;
    public int MaximumDamage;
    public int CurrentHitPoints;
    public int MaximumHitPoints;
    public bool IsAlive;

    public Monster(int id, string name, int minDamage, int maxDamage, int currentHp, int maxHp, bool isAlive)
    {
        ID = id;
        Name = name;
        MinimumDamage = minDamage;
        MaximumDamage = maxDamage;
        CurrentHitPoints = currentHp;
        MaximumHitPoints = maxHp;
        IsAlive = isAlive;
    }
}

