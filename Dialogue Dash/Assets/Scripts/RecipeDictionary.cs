using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using recipes;
using ingredients;

public class RecipeDictionary 
{
    private List<Recipe> entrees = new List<Recipe>();
    private List<Recipe> sides = new List<Recipe>();
    private List<Recipe> drinks = new List<Recipe>();


    public RecipeDictionary()
    {
        InitializeEntrees();
        InitializeSides();
        InitializeDrinks();
    }

    public void InitializeEntrees()
    {
        entrees.Add(new Dasher());
        entrees.Add(new Burgeroisie());
        entrees.Add(new BelieveBurger());
        entrees.Add(new CluckinBurger());
        entrees.Add(new EggersBurger());
    }

    public void InitializeSides()
    {
        sides.Add(new Fries());
        sides.Add(new MozzarellaSticks());
        sides.Add(new OnionRings());
        sides.Add(new SideSalad());

    }

    public void InitializeDrinks()
    {
        drinks.Add(new recipes.Drink(new Coke()));
        drinks.Add(new recipes.Drink(new ingredients.Sprite()));
        drinks.Add(new recipes.Drink(new DrPepper()));
        drinks.Add(new recipes.Drink(new Water()));
        drinks.Add(new recipes.Drink(new Tea()));
        drinks.Add(new recipes.Drink(new Coffee()));
    }

    public List<Recipe> GetEntrees()
    {
        return entrees;
    }

    public List<Recipe> GetDrinks()
    {
        return drinks;
    }

    public List<Recipe> GetSides()
    {
        return sides;
    }

}
