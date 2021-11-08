using Facebook.WitAi;
using Facebook.WitAi.Lib;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cook : Interactable
{
    [SerializeField] private Wit wit;

    [SerializeField]
    TextMeshProUGUI dialogue;

    [SerializeField]
    GameObject dialogueBox;

    private void OnValidate()
    {
        if (!wit) wit = GetComponent<Wit>();
    }

    public override void Interact()
    {
        wit.Activate();
    }

    public void addOrder(WitResponseNode resp)
    {
        dialogue.text = WitResultUtilities.GetIntentName(resp) + " " +  WitResultUtilities.GetFirstEntityValue(resp, "menu_item:menu_item");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        dialogueBox.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dialogueBox.SetActive(false);
    }
}
