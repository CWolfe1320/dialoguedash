using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Customer : Interactable
{
    public string message = "Howdy, table for one please";
    
    public override void Interact(){
        Debug.Log(message);
    }
}