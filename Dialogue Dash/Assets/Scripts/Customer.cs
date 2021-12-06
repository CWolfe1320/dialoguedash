using recipes;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using Facebook.WitAi;
using Facebook.WitAi.Lib;
using static System.Math;

public class Customer : Interactable
{
    [SerializeField]
    TextMeshProUGUI dialogue;

    [SerializeField]
    GameObject dialogueBox;

    [SerializeField]
    GameObject playerTray, tableTray, interactBubble;

    [SerializeField]
    private Wit wit;

    private string dialogueText;

    private Recipe entree;
    private Recipe side;
    private Recipe drink;


    private RecipeDictionary recipeDict = new RecipeDictionary();

    bool orderStarted = false;
    bool initialSpeech = false;


    private bool orderMatch = false;
    public void CheckOrder(ref Player playerScript)
    {
        orderMatch = false;
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
        double greetingFactor = 0;
        double sentimentFactor = 0;
        double welcomeFactor = 0;
        double tipPercentage = 0;
        double finalTip = 0;

        foreach (Recipe rec in playerScript.getOrder().getItems())
        {
            payment = payment + rec.GetFinalPrice();
        }

        if (greetingExist)
            greetingFactor = (double) Random.Range(0.05f, 0.1f);
        if (positiveSentiment)
            sentimentFactor = (double) Random.Range(0.05f, 0.2f);
        if (neutralSentiment)
            sentimentFactor = (double) Random.Range(0.05f, 0.2f) / 2.0f;
        if (welcomeExist)
            welcomeFactor = (double) Random.Range(0.05f, 0.15f);

        tipPercentage = greetingFactor + sentimentFactor + welcomeFactor;
        finalTip = System.Math.Round(tipPercentage * payment, 2);
        
        if(tipPercentage > 0.3)
            dialogue.text = dialogue.text + " Also, thank you for the excellent service, I've added a tip of $" + finalTip + " to the payment!";
        else if(tipPercentage > 0.14)
            dialogue.text = dialogue.text + " Also, thanks for doing your job. I've added a tip of $" + finalTip + " to the payment.";
        else if(tipPercentage > 0)
            dialogue.text = dialogue.text + " Also, you barely did your job, but I guess I'll be nice. I've added a tip of $" + finalTip + " to the payment.";
        else
            dialogue.text = dialogue.text + " Also, the service here was terrible so you aren't getting a tip.";

        playerScript.AddCash(payment + finalTip);
    }

    public override void Interact() {

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
            initialSpeech = false;
            orderMatch = false;
        }

        else if (orderStarted)
        {
            LoadInterimDialogue();
            LoadRandomInterimDialogue();

            dialogue.text = interimUtteranceMessage;
        }
        else if (!initialSpeech)
        {
            wit.Activate();
            dialogue.text = "Listening...";
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


    private bool positiveSentiment = false;
    private bool neutralSentiment = false;
    private bool negativeSentiment = false;
    private bool greetingExist = false;
    private bool welcomeExist = false;


    public void getGreeting(WitResponseNode resp)
    {
        Debug.Log(resp["intents"][0]["name"].Value + " intent");
        if (resp["intents"][0]["name"].Value == "take_order")
        {
            positiveSentiment = false;
            neutralSentiment = false;
            negativeSentiment = false;
            greetingExist = false;
            welcomeExist = false;

            initialSpeech = true;

            if (resp["traits"]["wit$sentiment"][0]["value"].Value == "positive")
                positiveSentiment = true;
            else if (resp["traits"]["wit$sentiment"][0]["value"].Value == "neutral")
                neutralSentiment = true;
            else
                negativeSentiment = true;

            if (resp["traits"]["wit$greetings"][0]["value"].Value == "true")
                greetingExist = true;

            if (resp["traits"]["welcome"][0]["value"].Value == "true")
                welcomeExist = true;

        }
        dialogue.text = "Press E to interact...";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        dialogue.text = "Press E to interact...";
        dialogueBox.SetActive(true);
        interactBubble.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dialogueBox.SetActive(false);
        interactBubble.SetActive(false);
    }


    public void RandomizeOrder()
    {

        List<Recipe> entrees = recipeDict.GetEntrees();//5
        List<Recipe> drinks = recipeDict.GetDrinks();//6
        List<Recipe> sides = recipeDict.GetSides();//4


        entree = entrees[UnityEngine.Random.Range(0, 5)];
        drink = drinks[UnityEngine.Random.Range(0, 6)];
        side = sides[UnityEngine.Random.Range(0, 4)];
           
    }


    public string posNeuOrderUtteranceFile = "posNeuSentimentOrderUtterances";
    public string negOrderUtteranceFile = "negativeSentimentOrderUtterances";
    public string greetingUtteranceFile = "greetingUtterances";
    public string noGreetingUtteranceFile = "noGreetingUtterances";
    //private string orderUtteranceFile = "initialOrderUtterances";
    private string[] orderUtteranceContents;
    private string[] greetingUtteranceContents;
    public void LoadOrderDialogue()
    {

        TextAsset txtAssets;

        if (positiveSentiment || neutralSentiment)
        {
            txtAssets = (TextAsset)Resources.Load(posNeuOrderUtteranceFile);
        }
        else
            txtAssets = (TextAsset)Resources.Load(negOrderUtteranceFile);

        if (txtAssets != null)
        {
            orderUtteranceContents = (txtAssets.text.Split('\n'));
        }

        if (greetingExist)
        {
            txtAssets = (TextAsset)Resources.Load(greetingUtteranceFile);
        }
        else
            txtAssets = (TextAsset)Resources.Load(noGreetingUtteranceFile);

        if(txtAssets != null)
        {
            greetingUtteranceContents = (txtAssets.text.Split('\n'));
        }

        /*for(int i = 0; i < orderUtteranceContents.Length - 1; ++i)
        {
            Debug.Log(orderUtteranceContents[i]);
        }*/

    }
    private string orderUtteranceMessage;

    public void LoadRandomOrderDialogue()
    {
        orderUtteranceMessage = greetingUtteranceContents[UnityEngine.Random.Range(1, orderUtteranceContents.Length - 2)];
        orderUtteranceMessage = orderUtteranceMessage.Substring(0,orderUtteranceMessage.Length-1) + " ";

        orderUtteranceMessage = orderUtteranceMessage + orderUtteranceContents[UnityEngine.Random.Range(0, orderUtteranceContents.Length - 1)];

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