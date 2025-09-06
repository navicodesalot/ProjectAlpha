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

    public static void Main()
    {
        // hi
    }

}