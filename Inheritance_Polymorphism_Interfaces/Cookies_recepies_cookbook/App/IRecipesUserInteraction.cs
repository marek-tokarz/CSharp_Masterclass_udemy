using Cookies_recepies_cookbook.Recipes.Ingredients;
using Cookies_recepies_cookbook.Recipes;

namespace Cookies_recepies_cookbook.App;

public interface IRecipesUserInteraction
{
    void ShowMessage(string message);
    void Exit();
    void PrintExistingRecipes(IEnumerable<Recipe> allRecipes);
    void PromptToCreateRecipe();
    IEnumerable<Ingredient> ReadIngredientsFromUser();
}
