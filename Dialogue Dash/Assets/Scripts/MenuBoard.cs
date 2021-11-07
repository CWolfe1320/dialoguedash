using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBoard : Interactable
{

    [SerializeField]
    GameObject menuUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        menuUI.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        menuUI.SetActive(false);
    }

    public override void Interact()
    {
        Debug.Log("Works!");
    }
}
