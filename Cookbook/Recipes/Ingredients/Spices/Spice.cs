namespace Cookbook.Recipes.Ingredients.Spices;

public abstract class Spice : Ingredient
{
	public override string Instructions => $"Half a teaspoon. {base.Instructions}";
}