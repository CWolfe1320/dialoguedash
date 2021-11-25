using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public Order heldOrder; 
    public bool holdingOrder = false;
    [SerializeField]
    private TextMeshProUGUI cashCounter;
    private double cash;
    public Order getOrder(){
        return heldOrder;
    }
    private void Start()
    {
        cash = 0;

        cashCounter.text = cash.ToString();
    }

    public void AddCash(double payment)
    {
        cash = cash + payment;
        cashCounter.text = cash.ToString();
    }

    public void setOrder(Order customerOrder){
        heldOrder = customerOrder;
        holdingOrder = true;
    }
}
