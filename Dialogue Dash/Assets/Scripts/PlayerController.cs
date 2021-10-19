using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public Rigidbody2D rb;
    private Vector2 movement;

    public string order; 
    public Vector2 interactSize = new Vector2(1f, 1f);


    // Update is called once per frame as such we put input mappings here 
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.E))
            CheckInteraction();

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

    }

    // Not framerate dependent
    void FixedUpdate(){
        // Movement function 
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }


    private void CheckInteraction(){
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, interactSize, 0, Vector2.zero);

        if(hits.Length > 0){
            foreach(RaycastHit2D rc in hits){
                if(rc.transform.GetComponent<Interactable>()){
                    rc.transform.GetComponent<Interactable>().Interact();
                    return;
                }
            }
        }
    }
}
