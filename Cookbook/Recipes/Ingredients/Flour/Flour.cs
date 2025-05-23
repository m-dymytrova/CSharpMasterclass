namespace Cookbook.Recipes.Ingredients.Flour;

public abstract class Flour : Ingredient
{
	public override string Instructions => $"Sieve. {base.Instructions}";
}