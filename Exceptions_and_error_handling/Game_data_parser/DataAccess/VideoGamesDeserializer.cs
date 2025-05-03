using System.Text.Json;

public class VideoGamesDeserializer : IVideoGamesDeserializer
{
    private readonly IUserInteractor _userInteractor;

    public VideoGamesDeserializer(IUserInteractor userInteractor)
    {
        _userInteractor = userInteractor;
    }

    public List<VideoGame> DeserializeFrom(string fileName, string fileContents)
    {
        try
        {
            return JsonSerializer.Deserialize<List<VideoGame>>(fileContents);
        }
        catch (JsonException ex)
        {
            var originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            _userInteractor.PrintError($"JSON in {fileName} file was not " +
                $"in a valid format. JSON body:");
            _userInteractor.PrintError(fileContents);
            Console.ForegroundColor = originalColor;

            throw new JsonException($"{ex.Message} The file is: {fileName}", ex);
        }

    }
}
