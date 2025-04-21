namespace Cookies_recepies_cookbook.Recipes.Ingredients;

public class Butter : Ingredient
{
    public override int Id => 3;
    public override string Name => "Butter";
    public override string PreparationInstructions => 
        $"Melt on a low heat. {base.PreparationInstructions}";
}
