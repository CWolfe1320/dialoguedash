using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Order heldOrder; 
    
    public Order getOrder(){
        return heldOrder;
    }

    public void setOrder(Order customerOrder){
        heldOrder = customerOrder;
    }
}
