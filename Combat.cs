public static class Combat
{
    // outside of the rest to prevent duplicating random effect
    private static Random random = new Random();

    // generates damage
    public static int DamageGenerator(Weapon weapon)
    {

        int damage = random.Next(weapon.MinimumDamage, weapon.MaximumDamage + 1);
        return damage;
    }

    public static void PlayerDamageTaken(Player player, Monster monster)
    {
        player.CurrentHitPoints -= monster.MaximumDamage;
    }

    public static void MonsterDamageTaken(Monster monster, Weapon weapon)
    {
        int damage = DamageGenerator(weapon);
        monster.CurrentHitPoints -= damage;
    }

    public static void Main(Player player, Monster monster, Weapon weapon)
    {
        while (player.CurrentHitPoints != 0 || monster.CurrentHitPoints != 0)
        {
            Console.WriteLine(@$"
    {player.Name} HP: {player.CurrentHitPoints}
    {monster.Name} HP: {monster.CurrentHitPoints}
    THIS WILL HURT. OW!
        ");

            Console.ReadLine();

            


        }
    }

}