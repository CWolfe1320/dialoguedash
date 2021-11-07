using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : Interactable
{
    //Table variables (tableNum could be replace by a string if necessary later)
    public int tableNum; 
    public Customer customer;
    public Order dummyOrder;    

    // Start is called before the first frame update
    public override void Interact(){
        if(customer.inspectOrder(dummyOrder)){
            customer.getPayment();
        }
        else{
            customer.leaveRestaurant();
        }
    }

}
