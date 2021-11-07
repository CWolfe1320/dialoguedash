using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using recipes;
using UnityEngine.UI;

public class Order : MonoBehaviour
{
    public int table; 
    public List<Recipe> items = new List<Recipe>(); 
    double finalPrice;
    [SerializeField]Sprite tray; 
    //TODO
    //Add serialized field for sprite

    public Order(string tableNumber, List<Recipe> orderItems){
        items = orderItems;
        table = int.TryParse(tableNumber);
    }

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

    public bool compareOrder(Order customerOrder){
        bool isEqual = false;
        foreach(Recipe oRec in order){
            foreach(Recipe cRec in customerOrder){
                if(oRec.compareRecipe(cRec)){
                    isEqual = true;
                    break;
                }
                else{
                    isEqual = false;
                }
            }
        }
        return true;
    }


    // public void AllocateOrder()
    // {
    //     items.Add(new Recipe());
    // }

}
