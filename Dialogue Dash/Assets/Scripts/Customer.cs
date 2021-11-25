using recipes;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;


public class Customer : Interactable
{
    [SerializeField]
    TextMeshProUGUI dialogue;

    [SerializeField]
    GameObject dialogueBox;

    [SerializeField]
    GameObject playerTray, tableTray;

    private string dialogueText;


    private Recipe entree;
    private Recipe side;
    private Recipe drink;


    private RecipeDictionary recipeDict = new RecipeDictionary();

    bool orderStarted = false;



    private bool orderMatch = false;
    public void CheckOrder(ref Player playerScript)
    {
        List<Recipe> activeRecipes = new List<Recipe>();
        activeRecipes.Add(entree);
        activeRecipes.Add(side);
        activeRecipes.Add(drink);
        
        Order activeOrder = new Order(activeRecipes);

        if (playerScript.getOrder().compareOrder(activeOrder))
        {
            orderMatch = true;
        }
    }

    public void GetPayment(ref Player playerScript)
    {
        double payment = 0;

        foreach (Recipe rec in playerScript.getOrder().getItems())
        {
            payment = payment + rec.GetFinalPrice();
        }

        playerScript.AddCash(payment);
    }

    public override void Interact(){

        GameObject player = GameObject.Find("player");
        Player playerScript = player.GetComponent<Player>();

        if (orderStarted && playerScript.holdingOrder)
        {
            playerTray.SetActive(false);
            CheckOrder(ref playerScript);
            tableTray.SetActive(true);
            playerScript.holdingOrder = false;
            orderStarted = false;
            
            if (orderMatch)
            {
                dialogue.text = "This looks delicious! Thank you!";
                GetPayment(ref playerScript);
            }
            else
            {
                dialogue.text = "This looks tasty, but it isn't my order! I'm not paying for this!";
            }
        }

        else if (orderStarted)
        {
            LoadInterimDialogue();
            LoadRandomInterimDialogue();

            dialogue.text = interimUtteranceMessage;
        }
        else
        {
            RandomizeOrder();

            LoadOrderDialogue();
            LoadRandomOrderDialogue();

            dialogue.text = orderUtteranceMessage;
            orderStarted = true;

            tableTray.SetActive(false);
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        dialogue.text = "Press E to interact...";
        dialogueBox.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dialogueBox.SetActive(false);
    }


    public void RandomizeOrder()
    {

        List<Recipe> entrees = recipeDict.GetEntrees();//5
        List<Recipe> drinks = recipeDict.GetDrinks();//6
        List<Recipe> sides = recipeDict.GetSides();//4

        entree = entrees[UnityEngine.Random.Range(1,5)];
        drink = drinks[UnityEngine.Random.Range(1, 6)];
        side = sides[UnityEngine.Random.Range(1, 4)];

    }


    public string orderUtteranceFile = "initialOrderUtterances";
    private string[] orderUtteranceContents;
    public void LoadOrderDialogue()
    {
        TextAsset txtAssets = (TextAsset)Resources.Load(orderUtteranceFile);

        if(txtAssets != null)
        {
            orderUtteranceContents = (txtAssets.text.Split('\n'));
        }

        /*for(int i = 0; i < orderUtteranceContents.Length - 1; ++i)
        {
            Debug.Log(orderUtteranceContents[i]);
        }*/
        
    }
    private string orderUtteranceMessage;

    public void LoadRandomOrderDialogue()
    {
        orderUtteranceMessage = orderUtteranceContents[UnityEngine.Random.Range(0, orderUtteranceContents.Length - 1)];

        CorrectOrderDialogue();
    }

    public void CorrectOrderDialogue()
    {
        string temp = orderUtteranceMessage;
        temp = temp.Replace("$RandEntree_Item", FixRecipeNames(entree.GetRecipeName()));
        temp = temp.Replace("$RandSide_Item", FixRecipeNames(side.GetRecipeName()));
        temp = temp.Replace("$RandDrink_Item", FixRecipeNames(drink.GetRecipeName()));


        orderUtteranceMessage = temp;
    }

    public string interimUtteranceFile = "interimOrderUtterances";
    private string[] interimUtteranceContents;
    public void LoadInterimDialogue()
    {
        TextAsset txtAssets = (TextAsset)Resources.Load(interimUtteranceFile);

        if(txtAssets != null)
        {
            interimUtteranceContents = (txtAssets.text.Split('\n'));
        }
    }

    private string interimUtteranceMessage;
    public void LoadRandomInterimDialogue()
    {
        interimUtteranceMessage = interimUtteranceContents[UnityEngine.Random.Range(0, interimUtteranceContents.Length)];

        CorrectInterimDialogue();
    }

    public void CorrectInterimDialogue()
    {
        string temp = interimUtteranceMessage;
        temp = temp.Replace("$RandEntree_Item", FixRecipeNames(entree.GetRecipeName()));
        temp = temp.Replace("$RandSide_Item", FixRecipeNames(side.GetRecipeName()));
        temp = temp.Replace("$RandDrink_Item", FixRecipeNames(drink.GetRecipeName()));


        interimUtteranceMessage = temp;
    }

    public string FixRecipeNames(string recipeName)
    {
        return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(recipeName.ToLower());
    }

}