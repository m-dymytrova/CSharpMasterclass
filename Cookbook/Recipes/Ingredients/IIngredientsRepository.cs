namespace Cookbook.Recipes.Ingredients;

public interface IIngredientsRepository
{
	public IEnumerable<Ingredient?> All { get; }
	public Ingredient? GetById(int ingredientId);
}