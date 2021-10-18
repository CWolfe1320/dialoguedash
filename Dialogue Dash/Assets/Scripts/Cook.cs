using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cook : Interactable
{
    private Queue<string> pendingOrders = new Queue<string>();
    private string activeOrder;

    public override void Interact(){
    }

    private string listenToPlayer(){
        return "[player order]";
    }

    private void setActiveOrder(){
        if(activeOrder == null)
            activeOrder = pendingOrders.Dequeue();
        return;
    }
}
