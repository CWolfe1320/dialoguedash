using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb; 
    private GameObject cook;
    private Cook cookScript;
    private Vector2 movement;


    // void Start(){
    //     rb = GetComponent<Rigidbody2D>();
    //     cook = GameObject.Find("chef");
    //     cookScript = cook.GetComponent<Cook>();
    // }

    // void Update(){

    // }

    // void FixedUpdate(){

    //     if(cookScript.isCooking()){
            
    //         Queue<string> prepInstructions = cookScript.getCookInstructions();
    //         while(cookScript.isCooking){

    //         }
    //     }
    // }

}
