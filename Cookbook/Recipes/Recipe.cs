using Cookbook.Recipes.Ingredients;

namespace Cookbook.Recipes;

public class Recipe(IEnumerable<Ingredient> ingredients)
{
	public IEnumerable<Ingredient> Ingredients { get; } = ingredients;

	public override string ToString()
	{
		var steps = Ingredients.Select(ingredient => $"{ingredient.Name}. {ingredient.Instructions}").ToList();

		return string.Join(Environment.NewLine, steps);
	}
	
}