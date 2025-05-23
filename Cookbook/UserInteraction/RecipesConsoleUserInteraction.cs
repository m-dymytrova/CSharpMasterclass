using Cookbook.Recipes;
using Cookbook.Recipes.Ingredients;

namespace Cookbook.UserInteraction;

public class RecipesConsoleUserInteraction(IIngredientsRepository ingredientsRepository) : IRecipesUserInteraction
{
	private readonly IIngredientsRepository _ingredientsRepository = ingredientsRepository;

	public void PrintRecipes(IEnumerable<Recipe> recipes)
	{
		if (recipes.Count() <= 0) return;
		var count = 1;
		Console.WriteLine("Recipe list:" + Environment.NewLine);
		foreach (var recipe in recipes)
		{
			Console.WriteLine($"*** {count} ****");
			Console.WriteLine(recipe);
			Console.WriteLine();
			count++;
		}
	}

	public void PromptToCreateRecipe()
	{
		Console.WriteLine("Add new recipe!");
		Console.WriteLine("Available ingredients:");

		foreach (var ingredient in _ingredientsRepository.All)
		{
			Console.WriteLine(ingredient);
		}
	}

	public IEnumerable<Ingredient> GetIngredientsFromPrompt()
	{
		bool stopReading = false;
		var ingredients = new List<Ingredient>();

		while (!stopReading)
		{
			Console.WriteLine("Choose ingredient by typing its Id or type anything else to finish.");
			var userInput = Console.ReadLine();

			if (int.TryParse(userInput, out int ingredientId))
			{
				var foundIngredient = _ingredientsRepository.GetById(ingredientId);
				if (foundIngredient is not null)
				{
					ingredients.Add(foundIngredient);
				}
			}
			else
			{
				stopReading = true;
			}
		}
		
		return ingredients;
	}
	
	public void ShowMessage(string message)
	{
		Console.WriteLine(message);
	}

	public void Exit()
	{
		Console.WriteLine("Press any key to exit...");
		Console.ReadKey();
	}
}