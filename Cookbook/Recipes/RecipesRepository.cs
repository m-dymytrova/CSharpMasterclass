using Cookbook.Recipes.Ingredients;
using Cookbook.StringRepositories;

namespace Cookbook.Recipes;

public class RecipesRepository(IStringRepository stringRepository, IIngredientsRepository ingredientsRepository) : IRecipesRepository
{
	private readonly IStringRepository _stringRepository = stringRepository;
	private readonly IIngredientsRepository _ingredientsRepository = ingredientsRepository;
	private const string Separator = ",";

	private Recipe RecipeFromString(string recipeFromFile)
	{
		var idsAsStrings = recipeFromFile.Split(Separator);
		var ingredients = idsAsStrings.Select(int.Parse).Select(id => _ingredientsRepository.GetById(id)).ToList();
		return new Recipe(ingredients);
	}

	public List<Recipe> Get(string filePath)
	{
		
		List<string> recipesFromFile = _stringRepository.Read(filePath);

		return recipesFromFile.Select(RecipeFromString).ToList();
	}

	public void Update(string filePath, List<Recipe> recipes)
	{
		var recipesAsIngredientIds = recipes.Select(recipe => recipe.Ingredients.Select(ingredient => ingredient.Id).ToList()).Select(allIds => string.Join(Separator, allIds)).ToList();
		_stringRepository.Write(filePath, recipesAsIngredientIds);
	}
}