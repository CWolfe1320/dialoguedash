using System.Collections;
using System.Collections.Generic;
using UnityEngine;  


public class Customer : Interactable
{
    public Order order;
    public string message = "Howdy, table for one please";
    
    public override void Interact(){
        Debug.Log(message);
    }

    public double getPayment(){
        return order.GetFinalPrice();
    }
    
    public bool inspectOrder(Order deliveredOrder){
        return true;
    }

    public void leaveRestaurant(){
        Destroy(this);
    }
}