using Cookbook.FileFormatting;
using Cookbook.Recipes;
using Cookbook.UserInteraction;

namespace Cookbook;

public class CookbookApp(IRecipesRepository recipesRepository, IRecipesUserInteraction recipesUserInteraction)
{
	public void Run()
	{
		var recipes = recipesRepository.Get(FileMetadata.FilePath);
		recipesUserInteraction.PrintRecipes(recipes);
		recipesUserInteraction.PromptToCreateRecipe();
		var ingredients = recipesUserInteraction.GetIngredientsFromPrompt();
		
		if (ingredients.Count() > 0)
		{
			var recipe = new Recipe(ingredients);
			recipes.Add(recipe);
			recipesRepository.Update(FileMetadata.FilePath, recipes);
			recipesUserInteraction.ShowMessage("Recipe added");
			recipesUserInteraction.ShowMessage(recipe.ToString());
		}
		else
		{
			recipesUserInteraction.ShowMessage("No ingredients were found.");
		}

		recipesUserInteraction.Exit();
	}
}