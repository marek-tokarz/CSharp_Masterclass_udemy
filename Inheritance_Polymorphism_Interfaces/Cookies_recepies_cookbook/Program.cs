using Cookies_recepies_cookbook.App;
using Cookies_recepies_cookbook.DataAcces;
using Cookies_recepies_cookbook.FileAccess;
using Cookies_recepies_cookbook.Recipes;
using Cookies_recepies_cookbook.Recipes.Ingredients;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace Program;

public static class Program
{
    public static void Main(string[] args)
    {
        const FileFormat Format = FileFormat.Json;

        IStringsRepository stringsRepostory = Format == FileFormat.Json ?
            new StringsJsonRepository() :
            new StringsTextualRepository();

        const string FileName = "recipes";
        var fileMetadata = new FileMetadata(FileName, Format);

        var ingredientsRegister = new IngredientsRegister();

        var cookiesRecipesApp = new CookiesRecipesApp(
            new RecipesRepository(
                stringsRepostory,
                ingredientsRegister),
            new RecipesConsoleUserInteraction(
                ingredientsRegister));
        cookiesRecipesApp.Run(fileMetadata.ToPath());
    }
}


    