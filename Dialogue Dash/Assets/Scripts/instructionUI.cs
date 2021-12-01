using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instructionUI : Interactable
{

    [SerializeField]//Scenes
    private GameObject movePanel, interactPanel, patronPanel, cookPanel, instructGroup, interactBubble;

   
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
        instructGroup.SetActive(true);
    }

    public void interactInruct()
    {
        interactPanel.SetActive(true);
    }

    public void moveInstruct()
    {
        movePanel.SetActive(true);
    }

    public void patronInstruct()
    {
        patronPanel.SetActive(true);
    }

    public void cookInstruct()
    {
        cookPanel.SetActive(true);
    }
    
    public void close()
    {
        instructGroup.SetActive(false);
    }

    public void disableCook()
    {
        cookPanel.SetActive(false);
    }

    public void disablePatron()
    {
        patronPanel.SetActive(false);
    }

    public void disableInteract()
    {
        interactPanel.SetActive(false);
    }

    public void disableMove()
    {
        movePanel.SetActive(false);
    }

}
