/* Pick a Pair - Memory Game
 * GameManagerScript.cs Script
 * Albert-Jan Scherrenburg
 * Student Number 1684118 */

// Used Libraries
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

//Main Class that runs the game
public class GameManagerScript : MonoBehaviour
{
    // Integers that are used to hold information about card states and other things
    public Sprite[] cardFace;
    public Sprite cardBack;
    public GameObject[] cards;
    public Text matchText;

    private bool _init = false;
    private int _matches = 13;

    // Checks if game is started. If so it will start the InitializeCards Void
    void Update()
    {
        if (!_init)
            InitializeCards();
    }

    // Void used to initialize the cards and Place each card value on the field
    void InitializeCards()
    {
        if (!_init)
            _init = true;

        int counter = 0;
        int pNum = 1;

        // Creates a list of numbers and then randomizes the list.
        var rand = new System.Random();
        var cardNums = Enumerable.Range(0, 13)
            .OrderBy(n => rand.Next());

        for (int id = 0; id < 2; id++)
        {
            // Loops through list of randomized numbers and assigns card values.
            foreach (var num in cardNums)
            {
                cards[counter].GetComponent<Card>().CardValue = num;
                cards[counter].GetComponent<Card>().PNum = pNum;
                cards[counter].GetComponent<Card>().Initialized = true;

                counter++;
            }
            pNum++;
        }
        print("TOTAL CARDS: " + cards.Length);

        // Goes through every instance to attach card value to card graphic
        foreach (GameObject c in cards)
        {
            print("card" + c.GetComponent<Card>().CardValue.ToString() + " initialized: " + c.GetComponent<Card>().Initialized.ToString());
            var card = c.GetComponent<Card>();
            card.GetComponent<Card>().SetupGraphics();
        }

        Card.DO_NOT = false;
    }

    // Pretty self explanatory what this does
    public Sprite GetCardBack()
    {
        try
        {
            return cardBack;
        }
        catch (System.Exception)
        {
            return null;
        }
    }

    public Sprite GetCardFace(int i)
    {
        try
        {
            return cardFace[i];
        }
        catch (System.Exception)
        {
            return null;
        }
    }

    // Checks if one or two cards are turned. If 2 are turned it starts CardComparison Void
    public void CheckCards()
    {
        List<int> c = new List<int>();
        for (int i = 0; i < cards.Length; i++)
        {
            if (cards[i].GetComponent<Card>().State == 1)
                c.Add(i);
        }
        if (c.Count == 2)
            CardComparison(c);
    }

    // Checks both turned cards to see if they are a match. Also checks if all mathces are found. If so the Completed scene is loaded
    void CardComparison(List<int> c)
    {
        Card.DO_NOT = true;

        int x = 0;

        if (cards[c[0]].GetComponent<Card>().CardValue == cards[c[1]].GetComponent<Card>().CardValue)
        {
            x = 2;
            _matches--;
            matchText.text = "Number of Matches To Go: " + _matches;
            if (_matches == 0)
                SceneManager.LoadScene("Completed");
        }
        for (int i = 0; i < c.Count; i++)
        {
            cards[c[i]].GetComponent<Card>().State = x;
            cards[c[i]].GetComponent<Card>().FalseCheck();
        }
    }
}
