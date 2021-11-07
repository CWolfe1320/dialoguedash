using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using recipes;
using UnityEngine.UI;

public class Order : MonoBehaviour
{
    int table; 
    List<Recipe> items = new List<Recipe>(); 
    double finalPrice;
    [SerializeField]Sprite tray; 
    //TODO
    //Add serialized field for sprite

    //Generates the final price. 
    void GenerateFinalPrice(){
        foreach(Recipe rec in items){   
            finalPrice += rec.GetFinalPrice();
        }
        return;
    }
    //Getter for final price 
    public double GetFinalPrice(){
        return finalPrice;
    }

    public bool compareOrder(Order order){
        return true;
    }


    public void AllocateOrder()
    {
        items.Add(new Recipe());
    }

}
