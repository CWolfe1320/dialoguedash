using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Order heldOrder; 
    public bool holdingOrder = false;
    
    public Order getOrder(){
        return heldOrder;
    }

    public void setOrder(Order customerOrder){
        heldOrder = customerOrder;
        holdingOrder = true;
    }
}
