using Cookbook.Recipes.Ingredients.Flour;
using Cookbook.Recipes.Ingredients.Spices;
using Cookbook.Recipes.Ingredients.Sugar;

namespace Cookbook.Recipes.Ingredients;

public class IngredientsRepository : IIngredientsRepository
{
	public IEnumerable<Ingredient?> All { get; } = new List<Ingredient?>
	{
		new WheatFlour(),
		new WhiteSugar(),
		new BrownSugar(),
		new Egg.Egg(),
		new Cardamon(),
		new Cinnamon()
	};

	public Ingredient? GetById(int ingredientId)
	{
		return All.FirstOrDefault(ingredient => ingredient != null && ingredient.Id == ingredientId);
	}
}