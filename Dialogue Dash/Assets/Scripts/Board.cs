using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orders : Interactable
{   
    public string[] customerOrders = {"fries", "more fries"};

    public override void Interact(){
        foreach(string s in customerOrders){
            Debug.Log(s);
        }
    }
}
