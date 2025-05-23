using Cookbook.Recipes;
using Cookbook.Recipes.Ingredients;

namespace Cookbook.UserInteraction;

public interface IRecipesUserInteraction
{
	void ShowMessage(string message);
	void Exit();
	void PrintRecipes(IEnumerable<Recipe> recipes);
	void PromptToCreateRecipe();
	IEnumerable<Ingredient> GetIngredientsFromPrompt();
}