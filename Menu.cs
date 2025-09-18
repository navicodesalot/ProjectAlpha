using System;
using System.Collections.Generic;

// hier maak ik een class aan waar een menu wordt aangemaakt 
// een menu die gecontrolled wordt met de arrow keys

public class Menu
{
    // een read only list van de menu opties die er zijn
    private readonly IList<string> _options;
    // title van het menu
    private readonly string _title;
    // houdt bij welke optie is geselecteerd
    private int _selectedIndex = 0;

    // Een constructor om een nieuw menu aan te maken 
    // geeft een nieuwe titel en lijst met nieuwe opties
    public Menu(string title, IList<string> options)
    {
        // slaat de title op
        _title = title;
        // opties opslaan mag geen null zijn 
        _options = options ?? throw new ArgumentNullException(nameof(options));

        // kijk als de lijst leeg is 
        // menu mist data
        if (_options.Count == 0) throw new ArgumentException("Menu error, add options");

    }

    // laat de gebruiker het menu zien totdat er op enter wordt gedrukt
    public int Show()
    {
        // blijft herhalen tot gebruiker enter drukt
        while (true)
        {
            // menu weergeven
            Draw();
            // Dit zorgt ervoor dat de ingedrukte key niet wordt getoont op de console
            ConsoleKey key = Console.ReadKey(intercept: true).Key;

            // kijk welke keys worden ingedrukt
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    // geebuiker gaat een selectie omhoog
                    // als je bovenaan staat, gave je over naar de onderste optie
                    _selectedIndex = (_selectedIndex - 1 + _options.Count) % _options.Count;
                    break;

                case ConsoleKey.DownArrow:
                    // gebruiker gaat een optie omlaag
                    // als je onderaan staat schiet je naar boven. 
                    _selectedIndex = (_selectedIndex + 1) % _options.Count;
                    break;

                case ConsoleKey.Enter:
                    // keus bevestigen return index en stop loop
                    return _selectedIndex;
            }
        }
    }

    // dit geeft de menu de vormgeving
    private void Draw()
    {
        // maak het scherm leeg
        Console.Clear();
        // schrijf de title van het menu op
        Console.WriteLine($"{_title}\n");

        // print alle opties maar geef de gesleecteerde optie een andere kleur
        for (int i = 0; i < _options.Count; i++)
        {
            // geef de geselecteerde een andere kleur
            if (i == _selectedIndex)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"> {_options[i]} <");
                Console.ResetColor();
            }
            else
            {
                // normale optie
                Console.WriteLine($"  {_options[i]}");
            }
        }
    }
}
