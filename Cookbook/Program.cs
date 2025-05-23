using Cookbook;
using Cookbook.FileFormatting.Enums;
using Cookbook.Recipes;
using Cookbook.Recipes.Ingredients;
using Cookbook.StringRepositories;
using Cookbook.UserInteraction;

var ingredientRepository = new IngredientsRepository();
IStringRepository stringRepository = Settings.FileFormatSetting == FileFormat.Json ? new StringJsonRepository() : new StringTextRepository();

var cookbookApp = new CookbookApp(
	new RecipesRepository(
		stringRepository,
		ingredientRepository), 
	new RecipesConsoleUserInteraction(ingredientRepository));
cookbookApp.Run();