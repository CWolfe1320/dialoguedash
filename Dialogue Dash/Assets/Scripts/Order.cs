using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using recipes;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;

public class Order : MonoBehaviour
{
    public int tableNo; 
    public List<Recipe> items = new List<Recipe>(); 
    
    public double finalPrice;
    [SerializeField]Sprite tray;    

    public Order(){

    }

    public Order(string tableString, List<Recipe> orderItems){
        this.items = orderItems;
        string temp = Regex.Replace(tableString, "[^0-9 _]", "");
        int.TryParse(temp, out tableNo);
    }

    //Generates the final price. 
    public void GenerateFinalPrice(){
        foreach(Recipe rec in items){   
            finalPrice += rec.GetFinalPrice();
        }
        return;
    }
    //Getter for final price 
    public double GetFinalPrice(){
        return finalPrice;
    }

    public List<Recipe> getItems(){
        return items; 
    }
    //Compare two orders to see if they are the same
    public bool compareOrder(Order customerOrder){
        bool isEqual = false;
        foreach(Recipe oRec in items){
            foreach(Recipe cRec in customerOrder.getItems()){
                if(oRec.compareRecipe(cRec)){
                    isEqual = true;
                    break;
                }
                else{
                    isEqual = false;
                }
            }
        }
        return isEqual;
    }
}
