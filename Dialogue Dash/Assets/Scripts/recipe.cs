using System.Collections;
using System.Collections.Generic;
using ingredients;

namespace recipes
{
    public abstract class Recipe //BASE CLASS
    {
        protected string recipeName;

        protected double basePrice;

        protected double finalPrice;

        protected Dictionary<Ingredient, List<string>> prepInstructions = new Dictionary<Ingredient, List<string>>();

        public Dictionary<Ingredient, List<string>> GetPrepInstructions()
        {
            return prepInstructions;
        }

        public double GetBasePrice()
        {
            return basePrice;
        }

        public void GenerateFinalPrice(List<Ingredient> with)
        {

            finalPrice = basePrice;

            for(int i = 0; i < with.Count; i++)
            {
                finalPrice = finalPrice + with[i].GetCost();
            }
        }

        public void GenerateFinalPrice()
        {
            finalPrice = basePrice;
        }

        public double GetFinalPrice()
        {
            return finalPrice;
        }

        public string GetRecipeName()
        {
            return recipeName;
        }
        
        public bool compareRecipe(Recipe comparedRecipe){
            return recipeName.Equals(comparedRecipe.GetRecipeName());
        }
    }


    class Dasher : Recipe
    {
        public Dasher(List<Ingredient> with)
        {
            recipeName = "the dasher";

            basePrice = 8.0;

            for (int i = 0; i < with.Count; i++)
            {
                prepInstructions.Add(with[i], with[i].GetDefaultInstructions());
            }

            GenerateFinalPrice(with);
        }

        public Dasher()
        {
            recipeName = "the dasher";

            basePrice = 8.0;

            prepInstructions.Add(new BurgerPatty(), new BurgerPatty().GetDefaultInstructions());
            prepInstructions.Add(new Lettuce(), new Lettuce().GetDefaultInstructions());
            prepInstructions.Add(new Onion(), new Onion().GetDefaultInstructions());
            prepInstructions.Add(new Tomato(), new Tomato().GetDefaultInstructions());

            GenerateFinalPrice();
        }
    }

    class Burgeroisie : Recipe
    {
        public Burgeroisie(List<Ingredient> with)
        {
            recipeName = "burgeroisie";

            basePrice = 20.0;

            for (int i = 0; i < with.Count; i++)
            {
                prepInstructions.Add(with[i], with[i].GetDefaultInstructions());
            }

            GenerateFinalPrice(with);
        }

        public Burgeroisie()
        {
            recipeName = "burgeroisie";

            basePrice = 20.0;

            prepInstructions.Add(new BurgerPatty(), new BurgerPatty().GetDefaultInstructions());
            prepInstructions.Add(new Lettuce(), new Lettuce().GetDefaultInstructions());
            prepInstructions.Add(new Onion(), new Onion().GetDefaultInstructions());
            prepInstructions.Add(new Tomato(), new Tomato().GetDefaultInstructions());
            prepInstructions.Add(new Pickle(), new Pickle().GetDefaultInstructions());
            prepInstructions.Add(new RedOnion(), new RedOnion().GetDefaultInstructions());
            prepInstructions.Add(new Jalepeno(), new Jalepeno().GetDefaultInstructions());
            prepInstructions.Add(new Sauerkraut(), new Sauerkraut().GetDefaultInstructions());
            prepInstructions.Add(new Bacon(), new Bacon().GetDefaultInstructions());
            prepInstructions.Add(new Egg(), new Egg().GetDefaultInstructions());
            prepInstructions.Add(new Avocado(), new Avocado().GetDefaultInstructions());
            prepInstructions.Add(new BleuCheese(), new BleuCheese().GetDefaultInstructions());
            prepInstructions.Add(new ColeSlaw(), new ColeSlaw().GetDefaultInstructions());
            prepInstructions.Add(new OnionRing(), new OnionRing().GetDefaultInstructions());
            prepInstructions.Add(new Mushroom(), new Mushroom().GetDefaultInstructions());


            GenerateFinalPrice();
        }
    }

    class BelieveBurger : Recipe
    {
        public BelieveBurger(List<Ingredient> with)
        {
            recipeName = "i cant believe its not burger";

            basePrice = 9.0;

            for (int i = 0; i < with.Count; i++)
            {
                prepInstructions.Add(with[i], with[i].GetDefaultInstructions());
            }

            GenerateFinalPrice(with);
        }

        public BelieveBurger()
        {
            recipeName = "i cant believe its not burger";

            basePrice = 9.0;

            prepInstructions.Add(new ImpossiblePatty(), new ImpossiblePatty().GetDefaultInstructions());
            prepInstructions.Add(new Lettuce(), new Lettuce().GetDefaultInstructions());
            prepInstructions.Add(new Onion(), new Onion().GetDefaultInstructions());
            prepInstructions.Add(new Tomato(), new Tomato().GetDefaultInstructions());

            GenerateFinalPrice();
        }
    }

    class CluckinBurger : Recipe
    {
        public CluckinBurger(List<Ingredient> with)
        {
            recipeName = "cluckin burger";

            basePrice = 9.0;

            for (int i = 0; i < with.Count; i++)
            {
                prepInstructions.Add(with[i], with[i].GetDefaultInstructions());
            }

            GenerateFinalPrice(with);
        }

        public CluckinBurger()
        {
            recipeName = "cluckin burger";

            basePrice = 9.0;

            prepInstructions.Add(new ChickenPatty(), new ImpossiblePatty().GetDefaultInstructions());
            prepInstructions.Add(new Pickle(), new Pickle().GetDefaultInstructions());

            GenerateFinalPrice();
        }
    }

    class EggersBurger : Recipe
    {
        public EggersBurger(List<Ingredient> with)
        {
            recipeName = "eggers can be cheesers";

            basePrice = 9.0;

            for (int i = 0; i < with.Count; i++)
            {
                prepInstructions.Add(with[i], with[i].GetDefaultInstructions());
            }

            GenerateFinalPrice(with);
        }

        public EggersBurger()
        {
            recipeName = "eggers can be cheesers";

            basePrice = 9.0;

            prepInstructions.Add(new BurgerPatty(), new BurgerPatty().GetDefaultInstructions());
            prepInstructions.Add(new AmericanCheese(), new AmericanCheese().GetDefaultInstructions());
            prepInstructions.Add(new Egg(), new Egg().GetDefaultInstructions());

            GenerateFinalPrice();
        }
    }


    class Hamburger : Recipe
    {
        public Hamburger(List<Ingredient> with)
        {
            recipeName = "hamburger";

            basePrice = 4.0;

            for(int i = 0; i < with.Count; i++)
            {
                prepInstructions.Add(with[i], with[i].GetDefaultInstructions());
            }

            GenerateFinalPrice(with);
        }
        public Hamburger()
        {

            recipeName = "hamburger";

            basePrice = 4.0;
    
            prepInstructions.Add(new BurgerPatty(), new List<string> { "stove"});
            prepInstructions.Add(new Bun(), new List<string> {});

            GenerateFinalPrice();
        }
    }
    
    class Drink : Recipe
    {
        public Drink(Ingredient choice)
        {
            recipeName = choice.GetIngredientName();

            basePrice = choice.GetCost();

            prepInstructions.Add(choice, choice.GetDefaultInstructions());

            GenerateFinalPrice();
        }
        public Drink()
        {
            recipeName = "water";

            basePrice = new Water().GetCost();

            prepInstructions.Add(new Water(), new List<string> { });

            GenerateFinalPrice();
        }
    }

    class Fries : Recipe
    {
        public Fries()
        {
            recipeName = "fries";

            basePrice = 4.0;

            prepInstructions.Add(new Potato(), new List<string> { "cutting board", "deep fryer" });

            GenerateFinalPrice();
        }
    }

    class MozzarellaSticks : Recipe
    {
        public MozzarellaSticks()
        {
            recipeName = "mozzarella sticks";

            basePrice = 4.0;

            prepInstructions.Add(new CheeseSticks(), new CheeseSticks().GetDefaultInstructions());

            GenerateFinalPrice();
        }
    }

    class OnionRings : Recipe
    {
        public OnionRings()
        {
            recipeName = "onion rings";

            basePrice = 4.0;

            prepInstructions.Add(new Onion(), new List<string> { "cutting board", "deep fryer" });

            GenerateFinalPrice();
        }
    }

    class SideSalad : Recipe
    {
        public SideSalad(List<Ingredient> with)
        {
            recipeName = "side salad";

            basePrice = 3.0;

            for (int i = 0; i < with.Count; i++)
            {
                prepInstructions.Add(with[i], with[i].GetDefaultInstructions());
            }

            GenerateFinalPrice(with);
        }
        public SideSalad()
        {
            recipeName = "side salad";

            basePrice = 3.0;

            prepInstructions.Add(new Lettuce(), new Lettuce().GetDefaultInstructions());

            prepInstructions.Add(new Lettuce(), new Lettuce().GetDefaultInstructions());

            GenerateFinalPrice();
        }

    }
}