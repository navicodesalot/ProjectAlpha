public static class Combat
{
    // outside of the rest to prevent duplicating random effect
    private static Random random = new Random();

    // generates player damage
    public static int weaponDamageGenerator(Weapon weapon)
    {

        int damage = random.Next(weapon.MinimumDamage, weapon.MaximumDamage + 1);
        return damage;
    }

    // generates monster damage
    public static int monsterDamageGenerator(Monster monster)
    {
        int damage = random.Next(monster.MinimumDamage, monster.MaximumDamage + 1);
        return damage;
    }

    // monster's swing
    public static int MonsterTurn(Player player, Monster monster)
    {
        int damage = monsterDamageGenerator(monster);
        player.CurrentHitPoints -= damage;
        return damage;
    }

    // player's swing
    public static int PlayerTurn(Monster monster, Weapon weapon)
    {
        int damage = weaponDamageGenerator(weapon);
        monster.CurrentHitPoints -= damage;
        return damage;
    }

    // player dodges
    public static int PlayerDodges(Player player, Monster monster)
    {
        int damage = monster.MaximumDamage - 2;
        player.CurrentHitPoints -= damage;
        return damage;
    }


    public static void StartCombat(Player player, Monster monster, Weapon weapon)
    {
        while (player.CurrentHitPoints > 0 && monster.CurrentHitPoints > 0)
        {
            Console.WriteLine(@$"
{player.Name} HP: {player.CurrentHitPoints}
{monster.Name} HP: {monster.CurrentHitPoints}
        ");
            Console.WriteLine("What will you do?");

            Console.WriteLine(@"
> A | SWING
> B | DODGE
            ");

            string action = Console.ReadLine()!.ToUpper();

            if (action == "A")
            {
                int damageDone = PlayerTurn(monster, weapon);
                Console.WriteLine($"You do {damageDone} damage!");

                if (monster.CurrentHitPoints > 0)
                {
                    int monstersDamageDone = MonsterTurn(player, monster);
                    Console.ReadLine();
                    Console.WriteLine($"The {monster.Name} does {monstersDamageDone} damage!");
                }
            }
            else if (action == "B")
            {
                int dodgedDamage = PlayerDodges(player, monster);
                Console.WriteLine($"You dodge! The {monster.Name} only does {dodgedDamage} damage.");
            }
            else
            {
                Console.WriteLine($"The {monster.Name} eyes you hungrily.");
            }

        }

        if (player.CurrentHitPoints <= 0)
        {
            Console.ReadLine();
            Console.WriteLine("You've been defeated!");
            // once we have a try again menu, it will be referred to here
        }
        else
        {
            Console.ReadLine();
            Console.WriteLine($"You defeated the {monster.Name}!");
        }
    }

}