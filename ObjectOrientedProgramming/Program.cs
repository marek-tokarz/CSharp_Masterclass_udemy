var names = new Names();
var path = new NamesFilePathBuilder().BuildFilePath();
var stringsTextualRepository = new StringsTextualRepositories();

if(File.Exists(path))
{
    Console.WriteLine("Names file already exists. Loading names.");
    var stringsFromFile = stringsTextualRepository.Read(path);
    names.AddNames(stringsFromFile);
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
    stringsTextualRepository.Write(path, names.All);
}
Console.WriteLine(new NamesFormatter().Format(names.All));
Console.ReadKey();

class NamesValidator
{
    public bool IsValid(string name)
    {
        return name.Length >= 2 &&
            name.Length < 25 &&
            char.IsUpper(name[0]) &&
            name.All(char.IsLetter);
    }
}

class StringsTextualRepositories
{
    private static readonly string Separator = Environment.NewLine;

    public List<string> Read(string filePath)
    {
        var fileContents = File.ReadAllText(filePath);
        return fileContents.Split(Environment.NewLine).ToList();
    }

    public void Write(string filePath, List<string> strings)
    {
        File.WriteAllText(filePath, string.Join(Environment.NewLine, strings));
    }  
}

class NamesFilePathBuilder
{
    public string BuildFilePath()
    {
        // for simplicity a file name is a fixed value
        return "names.txt";
    }
}

class NamesFormatter
{
    public string Format(List<string> names)
    {
        return string.Join(Environment.NewLine, names);
    }
}

class Names
{
    public List<string> All { get; } = new List<string>();
    private readonly NamesValidator _namesValidator = new NamesValidator();

    public void AddNames(List<string> stringsFromFile)
    {
        foreach(var name in stringsFromFile)
        {
            AddName(name);
        }
    }

    public void AddName(string name)
    {
        if(_namesValidator.IsValid(name))
        {
            All.Add(name);
        }
    }
}