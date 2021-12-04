using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBoard : Interactable
{

    [SerializeField]
    GameObject menuUI, interactBubble;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        interactBubble.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interactBubble.SetActive(false);
    }

    public override void Interact()
    {
        menuUI.SetActive(true);
    }

    public void close()
    {
        menuUI.SetActive(false);
    }
}
