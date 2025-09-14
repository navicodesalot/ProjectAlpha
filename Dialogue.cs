using System.Text.Json;

public class DialogueEntry
{
    public DialoguePart Start { get; set; }
    public DialoguePart Complete { get; set; }
}

public class DialoguePart
{
    public List<string> Sentences { get; set; }
}

public class DialogueManager
{
    private Dictionary<string, DialogueEntry> _dialogues;

    // actually loads the dialogue, main hoe
    public DialogueManager(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Dialogue file not found, silly!");
            _dialogues = new Dictionary<string, DialogueEntry>();
            return;
        }

        string json = File.ReadAllText(filePath);

        try
        {
            _dialogues = JsonSerializer.Deserialize<Dictionary<string, DialogueEntry>>(json);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error reading dialogue JSON: " + ex.Message);
            _dialogues = new Dictionary<string, DialogueEntry>();
        }
    }

    public void ShowStartDialogue(int locationID)
    {
        string key = locationID.ToString();
        if (!_dialogues.ContainsKey(key))
        {
            Console.WriteLine($"No start dialogue here: {locationID}");
            return;
        }

        DialogueEntry dialogue = _dialogues[key];
        if (dialogue.Start?.Sentences == null) return;

        foreach (var sentence in dialogue.Start.Sentences)
        {
            Console.WriteLine(sentence);
            Console.ReadKey(true);
        }
    }

    public void ShowCompleteDialogue(int locationID)
    {
        string key = locationID.ToString();
        if (!_dialogues.ContainsKey(key))
        {
            Console.WriteLine($"No dialogue available here: {locationID}");
            return;
        }

        DialogueEntry dialogue = _dialogues[key];
        if (dialogue.Complete?.Sentences == null) return;

        foreach (var sentence in dialogue.Complete.Sentences)
        {
            Console.WriteLine(sentence);
            Console.ReadKey(true);
        }
    }
}
