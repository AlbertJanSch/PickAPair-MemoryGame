/* Pick a Pair - Memory Game
 * Card.cs Script
 * Albert-Jan Scherrenburg
 * Student Number 1684118 */

// Used Libraries
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Assets.Scripts;


// Main Class that handles cards
public class Card : MonoBehaviour
{

    // Bool used in FlipCard void
    public static bool DO_NOT = false;

    // Integers that are used to hold information about card states etc
    [SerializeField]
    private int _state;
    [SerializeField]
    private int _cardValue;
    [SerializeField]
    private bool _initialized = false;

    public int PNum { get; set; }

    private Sprite _cardBack;
    private Sprite _cardFace;

    private GameObject _manager;


    // Void that starts all cards off in state 0 by default (meaning all cards will be faced down)
    void Start()
    {
        _state = 0;
        _manager = GameObject.FindGameObjectWithTag("Manager");
    }

    // Void that is used to load in a card image whenever the player clicks on a card
    public void SetupGraphics()
    {
        print("Attempting too load card: " + CardValue);
        print("manager is null: " + (_manager == null).ToString());
        _cardBack = _manager.GetComponent<GameManagerScript>().GetCardBack();
        // Cards are loaded in from the "Deck1" folder inside the Images folder. Image names range from 1_1-1_13 and 2_1-2_13
        _cardFace = _manager.GetComponent<SpriteLoader>().LoadSprite(@"..\Images\Deck1\" + PNum + "_" + (_cardValue + 1) + ".png");
        print("Card loaded successfully: " + CardValue);
    }

    // Void that is used to flip a card when a player clicks on it
    public void FlipCard()
    {
        // Checks the state of the card, meaning if they are faced down and the player clicks on it, it will be flipped
        if (_state == 0)
            _state = 1;
        else if (_state == 1)
            _state = 0;

        print("card state: " + _state);

        // Checks if card needs to be faced down again or not
        if (_state == 0 && !DO_NOT)
            GetComponent<Image>().sprite = _cardBack;
        else if (_state == 1 && !DO_NOT)
            GetComponent<Image>().sprite = _cardFace;

        _manager.GetComponent<GameManagerScript>().CheckCards();
    }

    // Used to retrieve information
    public int CardValue
    {
        get { return _cardValue; }
        set { _cardValue = value; }
    }

    public int State
    {
        get { return _state; }
        set { _state = value; }
    }

    public bool Initialized
    {
        get { return _initialized; }
        set { _initialized = value; }
    }

    public void FalseCheck()
    {
        StartCoroutine(Pause());

    }

    // When card is turned, wait for 1 second and then turn card again if nessecary
    IEnumerator Pause()
    {
        yield return new WaitForSeconds(1);
        if (_state == 0)
            GetComponent<Image>().sprite = _cardBack;
        else if (_state == 1)
            GetComponent<Image>().sprite = _cardFace;
        DO_NOT = false;
    }
}
