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
            var actions = new List<string>
            {
                "SWING",
                "DODGE"
            };

            var menu = new Menu($"{monster.Name}'s health : {monster.CurrentHitPoints} || {player.Name}'s health: {player.CurrentHitPoints}\nWhat will you do?", actions);

            int action = menu.Show();
            Console.Clear();

            if (action == 0)
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
            else if (action == 1)
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
            monster.IsAlive = false;
        }
    }

}
/* voor het testen van combat
                    Player player = new Player();
                    player.Name = "Test Wizard";
                    player.CurrentHitPoints = 20;
                    player.MaximumHitPoints = 20;
                    player.CurrentWeapon = World.Weapons[0]; // Or use World.WeaponByID(World.WEAPON_ID_RUSTY_SWORD);

                    Monster monster = World.Monsters[1]; // Or use World.MonsterByID(World.MONSTER_ID_RAT);

                    Combat.StartCombat(player, monster, player.CurrentWeapon);
*/