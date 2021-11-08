using Facebook.WitAi;
using Facebook.WitAi.Lib;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class WitActivation : MonoBehaviour
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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            wit.Activate();
        }
    }

    public void addOrder(WitResponseNode resp)
    {
        dialogue.text = WitResultUtilities.GetIntentName(resp) + WitResultUtilities.GetFirstEntityValue(resp, "menu_item:menu_item");
    }
}


