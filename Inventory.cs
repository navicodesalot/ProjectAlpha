using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

public class Inventory
{
    // Sla de wapens op in een lijst van objects
    private List<Weapon> _weapons = new List<Weapon>();

    // public read only 
    public List<Weapon> Weapons
    {
        get { return _weapons; }
    }
    // de wapens toevoegen aan de inventory 
    // en roep de methode aan met het weapon object
    public void AddWeapon(Weapon weapon)
    {
        // voeg toe als er een waarde is
        if (weapon != null)
        {
            _weapons.Add(weapon);
        }
    }

    // return de lijst met weapons
    public List<Weapon> GetWeapons()
    {
        return _weapons;
    }

    //  laat de inhoud van je inventory zien op de console
    public void ShowInventory()
    {
        // als er niets in je in inventory zit
        if (_weapons.Count == 0)
        {
            Console.WriteLine("Inventory is empty...");
            return;
        }
        Console.WriteLine("=== Inventory ===");

        //  loop door de items in je inventory
        foreach (Weapon i in _weapons)
        {
            // toon info van de items
            Console.WriteLine($"{i.ID}:  {i.Name} ({i.MinimumDamage}-{i.MaximumDamage} damage)");
        }
    }
}   