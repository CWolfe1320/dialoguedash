using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb; 
    public bool isCooking; 
    private GameObject cook;
    private Cook cookScript;


    void Start(){
        rb = GetComponent<Rigidbody2D>();
        cook = GameObject.Find("chef");
        cookScript = cook.GetComponent<Cook>();
    }

    void FixedUpdate(){
        
    }

}
