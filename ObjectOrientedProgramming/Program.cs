var names = new Names();
var path = names.BuildFilePath();
if(File.Exists(path))
{
    Console.WriteLine("Names file already exists. Loading names.");
    names.ReadFromTextFile();
}
else
{
    Console.WriteLine("Names file does not exists yet.");

    //let's imagine they are given by the user
    names.AddName("John");
    names.AddName("not a valid name");
    names.AddName("Claire");
    names.AddName("123 definitely not a valid name");

    Console.WriteLine("Saving names to a file.");
    names.WriteToTextFile();
}
Console.WriteLine(names.Format());
Console.ReadKey();

class Names
{
    private List<string> _names = new List<string>();

    public void AddName(string name)
    {
        if(IsValidName(name))
        {
            _names.Add(name);
        }
    }

    private bool IsValidName(string name)
    {
        return name.Length >= 2 &&
            name.Length < 25 &&
            char.IsUpper(name[0]) &&
            name.All(char.IsLetter);
    }

    public void ReadFromTextFile()
    {
        var fileContents = File.ReadAllText(BuildFilePath());
        var namesFromFile = fileContents.Split(Environment.NewLine).ToList();
        foreach(var name in namesFromFile)
        {
            AddName(name);
        }
    }

    public void WriteToTextFile()
    {
        File.WriteAllText(BuildFilePath(), Format());
    }

    public string BuildFilePath()
    {
        // for simplicity a file name is a fixed value
        return "names.txt";
    }

    public string Format()
    {
        return string.Join(Environment.NewLine, _names);
    }
}