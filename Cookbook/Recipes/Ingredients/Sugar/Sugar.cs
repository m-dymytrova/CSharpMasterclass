namespace Cookbook.Recipes.Ingredients.Sugar;

public abstract class Sugar : Ingredient
{
	public override string Instructions => $"One teaspoon. {base.Instructions}";
}