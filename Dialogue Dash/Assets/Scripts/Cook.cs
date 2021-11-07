using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cook : Interactable
{   
    // [SerializeField] private Wit wit;

    // 
    private Queue<Order> pendingOrders = new Queue<Order>();
    private Order activeOrder;

    public override void Interact(){
        // TODO
        Order newOrder = listenToPlayer();
        addOrder(newOrder);
    }

    //Adds order to the pending order queue
    private void addOrder(Order newOrder) {
        if(isOrderValid(newOrder))
            pendingOrders.Enqueue(newOrder);
    }

    private Order listenToPlayer() {
        // TODO
        /*
        var response = wit.activate(); 
        */
        Order newOrder = new Order();
        return newOrder;
    }

    private void setActiveOrder() {
        if(activeOrder == null)
            activeOrder = pendingOrders.Dequeue();
        return;
    }

    private bool isOrderValid(Order order) {
        // TODO
        return false;
    }

    //Invoke repeating for cooking tasks (ingredients)
}
