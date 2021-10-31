using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cook : Interactable
{
    private Queue<string> pendingOrders = new Queue<string>();
    private string activeOrder;

    public override void Interact(){
        // TODO
    }

    private void addOrder() {
        string playerOrder = "";
        playerOrder = listenToPlayer();

        if(isOrderValid(playerOrder))
            pendingOrders.Enqueue(playerOrder);
    }

    private string listenToPlayer() {
        // TODO
        return "[player order]";
    }

    private void setActiveOrder() {
        if(activeOrder == null)
            activeOrder = pendingOrders.Dequeue();
        return;
    }

    private bool isOrderValid(string order) {
        // TODO
        return false;
    }
}
