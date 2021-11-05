using System.Collections;
using System.Collections.Generic;


namespace ingredients
{
    abstract class Ingredient //BASE CLASS
    {

        protected string ingredientName;

        protected string storageLocation;

        protected double cost;

        protected List<string> defaultInstructions = new List<string>();

        public List<string> GetDefaultInstructions()
        {
            return defaultInstructions;
        }

        public string GetIngredientName()
        {
            return ingredientName;
        }

        public abstract string GetIngredientType();

        public string GetStorageLocation()
        {
            return storageLocation;
        }
        public double GetCost()
        {
            return cost;
        }
        
    }
    //INHERITABLE CLASSES
    abstract class Meat : Ingredient
    {
        public override string GetIngredientType()
        {
            return "meat";
        }
    }

    abstract class Vegetable : Ingredient
    {
        public override string GetIngredientType()
        {
            return "vegetable";
        }
    }

    abstract class Drink : Ingredient
    {
        public override string GetIngredientType()
        {
            return "drink";
        }
    }

    abstract class Dairy : Ingredient
    {
        public override string GetIngredientType()
        {
            return "dairy";
        }
    }

    abstract class Grain : Ingredient
    {
        public override string GetIngredientType()
        {
            return "grain";
        }
    }

    abstract class Condiment : Ingredient
    {
        public override string GetIngredientType()
        {
            return "condiment";
        }
    } 

    abstract class Processed : Ingredient
    {
        public override string GetIngredientType()
        {
            return "processed";
        }
    }
    //END INHERITABLE CLASSES
    //MEAT INGREDIENTS
    class BurgerPatty : Meat
    {
        public BurgerPatty()
        {
            defaultInstructions.Add("stove");

            ingredientName = "burger patty";

            storageLocation = "fridge";

            cost = 4.0;
        }
    }

    class ChickenPatty : Meat
    {
        public ChickenPatty()
        {
            defaultInstructions.Add("stove");

            ingredientName = "chicken patty";

            storageLocation = "fridge";

            cost = 5.0;
        }
    }

    class Bacon : Meat
    {
        public Bacon()
        {
            defaultInstructions.Add("stove");

            ingredientName = "bacon";

            storageLocation = "fridge";

            cost = 1.0;
        }
    }

    class Egg : Meat
    {
        public Egg()
        {
            defaultInstructions.Add("stove");

            ingredientName = "egg";

            storageLocation = "fridge";

            cost = 1.0;
        }
    }
    //END MEAT INGREDIENTS
    //VEGETABLE INGREDIENTS
    class ImpossiblePatty : Vegetable
    {
        public ImpossiblePatty()
        {
            defaultInstructions.Add("stove");

            ingredientName = "impossible patty";

            storageLocation = "fridge";

            cost = 5.0;
        }
    }
    class VegetablePatty : Vegetable
    {
        public VegetablePatty()
        {
            defaultInstructions.Add("stove");

            ingredientName = "vegetable patty";

            storageLocation = "fridge";

            cost = 4.0;
        }
    }

    class Pickle : Vegetable
    {
        public Pickle()
        {
            defaultInstructions.Add("cutting board");

            ingredientName = "pickle";

            storageLocation = "fridge";

            cost = 0;
        }
    }

    class Onion : Vegetable
    {
        public Onion()
        {
            defaultInstructions.Add("cutting board");
            defaultInstructions.Add("stove");

            ingredientName = "onion";

            storageLocation = "pantry";

            cost = 0;
        }
    }

    class RedOnion : Vegetable
    {
        public RedOnion()
        {
            defaultInstructions.Add("cutting board");

            ingredientName = "red onion";

            storageLocation = "pantry";

            cost = 0;
        }
    }

    class Tomato : Vegetable
    {
        public Tomato()
        {
            defaultInstructions.Add("cutting board");

            ingredientName = "tomato";

            storageLocation = "pantry";

            cost = 0;
        }
    }

    class Lettuce : Vegetable
    {
        public Lettuce()
        {
            defaultInstructions.Add("cutting board");

            ingredientName = "lettuce";

            storageLocation = "fridge";

            cost = 0;
        }
    }

    class Jalepeno : Vegetable
    {
        public Jalepeno()
        {
            defaultInstructions.Add("cutting board");

            ingredientName = "jalapeno";

            storageLocation = "fridge";

            cost = 0;
        }
    }

    class Potato : Vegetable
    {
        public Potato()
        {
            defaultInstructions.Add("cutting board");
            defaultInstructions.Add("oven");

            ingredientName = "potato";

            storageLocation = "pantry";

            cost = 1.0;
        }
    }

    class Avocado : Vegetable
    {
        public Avocado()
        {
            defaultInstructions.Add("cutting board");

            ingredientName = "avocado";

            storageLocation = "pantry";

            cost = 1.0;
        }
    }

    class Mushroom : Vegetable
    {
        public Mushroom()
        {
            defaultInstructions.Add("cutting board");

            ingredientName = "mushroom";

            storageLocation = "pantry";

            cost = 1.0;
        }
    }
    //END VEGETABLE INGREDIENTS
    //DRINK INGREDIENTS
    class Coke : Drink
    {
        public Coke()
        {
            ingredientName = "coke";

            storageLocation = "drink station";

            cost = 1.0;
        }
    }

    class Sprite : Drink
    {
        public Sprite()
        {
            ingredientName = "sprite";

            storageLocation = "drink station";

            cost = 1.0;
        }
    }

    class DrPepper : Drink
    {
        public DrPepper()
        {
            ingredientName = "dr pepper";

            storageLocation = "drink station";

            cost = 1.0;
        }
    }

    class Water : Drink
    {
        public Water()
        {
            ingredientName = "water";

            storageLocation = "drink station";

            cost = 0;
        }
    }

    class Tea : Drink
    {
        public Tea()
        {
            ingredientName = "tea";

            storageLocation = "drink station";

            cost = 1.0;
        }
    }

    class Coffee : Drink
    {
        public Coffee()
        {
            ingredientName = "coffee";
            
            storageLocation = "drink station";
            
            cost = 1.0;
        }
    }
    //END DRINK INGREDIENTS
    //DAIRY INGREDIENTS
    class AmericanCheese : Dairy
    {
        public AmericanCheese()
        {
            ingredientName = "american cheese";

            storageLocation = "fridge";

            cost = 0.75;
        }
    }

    class CheddarCheese : Dairy
    {
        public CheddarCheese()
        {
            ingredientName = "cheddar cheese";

            storageLocation = "fridge";

            cost = 1.0;
        }
    }

    class SwissCheese : Dairy
    {
        public SwissCheese()
        {
            ingredientName = "swiss cheese";

            storageLocation = "fridge";

            cost = 1.0;
        }
    }

    class ProvoloneCheese : Dairy
    {
        public ProvoloneCheese()
        {
            ingredientName = "provolone cheese";

            storageLocation = "fridge";

            cost = 1.0;
        }
    }

    class GoudaCheese : Dairy
    {
        public GoudaCheese()
        {
            ingredientName = "gouda cheese";

            storageLocation = "fridge";

            cost = 1.0;
        }
    }

    class MozzarellaCheese : Dairy
    {
        public MozzarellaCheese()
        {
            ingredientName = "mozzarella cheese";

            storageLocation = "fridge";

            cost = 1.0;
        }
    }

    class BleuCheese : Dairy
    {
        public BleuCheese()
        {
            ingredientName = "bleu cheese";

            storageLocation = "fridge";

            cost = 1.0;
        }
    }

    class CheeseSticks : Dairy
    {
        public CheeseSticks()
        {

            defaultInstructions.Add("deep fryer");

            ingredientName = "cheese sticks";

            storageLocation = "fridge";

            cost = 3.0;
        }
    }

    //END DAIRY INGREDIENTS
    //GRAIN INGREDIENTS
    class Bun : Grain
    {
        public Bun()
        {
            defaultInstructions.Add("oven");

            ingredientName = "bun";

            storageLocation = "pantry";

            cost = 0.5;
        }
    }
    //END GRAIN INGREDIENTS
    //CONDIMENT INGREDIENTS
    class Mayonaisse : Condiment
    {
        public Mayonaisse()
        {
            ingredientName = "mayonaisse";

            storageLocation = "fridge";

            cost = 0.25;
        }
    }

    class Ketchup : Condiment
    {
        public Ketchup()
        {
            ingredientName = "ketchup";

            storageLocation = "fridge";

            cost = 0.25;
        }
    }

    class Mustard : Condiment
    {
        public Mustard()
        {
            ingredientName = "mustard";

            storageLocation = "fridge";

            cost = 0.25;
        }
    }
    //END CONDIMENT INGREDIENTS
    //PROCESSED INGREDIENTS
    class ColeSlaw : Processed
    {
        public ColeSlaw()
        {
            ingredientName = "cole slaw";

            storageLocation = "fridge";

            cost = 1.0;
        }
    }

    class OnionRing : Processed
    {
        public OnionRing()
        {
            defaultInstructions.Add("deep fryer");

            ingredientName = "onion ring";

            storageLocation = "fridge";

            cost = 1.0;
        }
    }

    class Sauerkraut : Processed
    {
        public Sauerkraut()
        {
            defaultInstructions.Add("stove");
            
            ingredientName = "sauerkraut";

            storageLocation = "fridge";

            cost = 0.0;
        }
    }
    //END PROCESSED INGREDIENTS
}