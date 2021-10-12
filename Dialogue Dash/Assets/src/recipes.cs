using System.Collections;
using System.Collections.Generic;
using ingredients;

namespace recipes
{
    abstract class Recipe //BASE CLASS
    {
        protected string recipeName;

        protected Dictionary<Ingredient, List<string>> prepInstructions = new Dictionary<Ingredient, List<string>>();

        public Dictionary<Ingredient, List<string>> GetPrepInstructions()
        {
            return prepInstructions;
        }

    }

    class Hamburger : Recipe
    {
        public Hamburger(List<Ingredient> with)
        {
            recipeName = "hamburger";

            for(int i = 0; i < with.Count; i++)
            {
                prepInstructions.Add(with[i], with[i].GetDefaultInstructions());
            }

        }
        public Hamburger()
        {

            recipeName = "hamburger";

            prepInstructions.Add(new BurgerPatty(), new List<string> { "stove"});
            prepInstructions.Add(new Bun(), new List<string> {});
            
        }
    }
    
    class Drink : Recipe
    {
        public Drink(Ingredient choice)
        {
            recipeName = choice.GetIngredientName();

            prepInstructions.Add(choice, choice.GetDefaultInstructions());
        }
        public Drink()
        {
            recipeName = "water";

            prepInstructions.Add(new Water(), new List<string> { });
        }
    }

    class Fries : Recipe
    {
        public Fries()
        {
            recipeName = "fries";

            prepInstructions.Add(new Potato(), new List<string> { "cutting board", "deep fryer" });
        }
    }
}