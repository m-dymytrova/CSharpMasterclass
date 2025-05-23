namespace Cookbook.Recipes;

public interface IRecipesRepository
{
	List<Recipe> Get(string filePath);
	void Update(string filePath, List<Recipe> recipes);
}