using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class cardCollection : MonoBehaviour
{
    public AudioSource cardAddRemov;

    public static bool deckMadeBlue;
    public static bool deckMadeRed;

    public string cardName;

    public bool isInDeck;

    public int possibleAmount;

    public GameObject deck1;

    public GameObject deck2;

    public GameObject maker;

    public GameObject clone;

    public GameObject enoughLimit;

    public bool blueCard;

    public cardCollection cardMaker;

    public cardCollection clonedSelf;

    public bool travel;

    public bool arrived;

    float t;
    Vector2 startPosition;
    Vector2 target;
    float timeToReachTarget = 0.1f;

    float putIn = 0.1f;

    public GameObject canvas;

    public void Start()
    {
        if (System.IO.File.Exists(Application.persistentDataPath + "/deck.help"))
        {
            if (isInDeck == false && blueCard == true)
            {
                deckSaver data = deckLoader.LoadDeck();

                foreach (string cardy in data.deckBlue)
                {
                    if (cardy == cardName)
                    {
                        deckMadeBlue = true;

                        this.gameObject.GetComponent<Button>().onClick.Invoke();
                    }
                }
            }
            else if (isInDeck == false)
            {
                deckSaver data = deckLoader.LoadDeck();

                foreach (string cardy in data.deckRed)
                {
                    if (cardy == cardName)
                    {
                        deckMadeRed = true;

                        this.gameObject.GetComponent<Button>().onClick.Invoke();
                    }
                }
            }
        }

        if (isInDeck == true && arrived == true)
        {
            if (blueCard == true)
            {
                this.transform.SetParent(deck1.transform, false);

                CardManager.cardsInDeckBlue++;
            }
            else
            {
                this.transform.SetParent(deck2.transform, false);

                CardManager.cardsInDeckRed++;
            }

            foreach (Transform child in this.transform)
            {
                Destroy(child.gameObject);
            }

            if (deckMadeBlue == false && blueCard == true)
            {
                cardAddRemov.Play();
            }

            if (deckMadeRed == false && blueCard == false)
            {
                cardAddRemov.Play();
            }

        }
        else if (isInDeck)
        {
            startPosition = maker.transform.localPosition;
            if (blueCard == true)
            {
                if (CardManager.cardsInDeckBlue == 0)
                {
                    target = new Vector2(-137.5f, 120);
                }
                else if (CardManager.cardsInDeckBlue == 1)
                {
                    target = new Vector2(-112.5f, 120);
                }
                else if (CardManager.cardsInDeckBlue == 2)
                {
                    target = new Vector2(-87.5f, 120);
                }
                else if (CardManager.cardsInDeckBlue == 3)
                {
                    target = new Vector2(-62.5f, 120);
                }
                else if (CardManager.cardsInDeckBlue == 4)
                {
                    target = new Vector2(-37.5f, 120);
                }
                else if (CardManager.cardsInDeckBlue == 5)
                {
                    target = new Vector2(-12.5f, 120);
                }
                else if (CardManager.cardsInDeckBlue == 6)
                {
                    target = new Vector2(12.5f, 120);
                }
                else if (CardManager.cardsInDeckBlue == 7)
                {
                    target = new Vector2(37.5f, 120);
                }
                else if (CardManager.cardsInDeckBlue == 8)
                {
                    target = new Vector2(62.5f, 120);
                }
                else if (CardManager.cardsInDeckBlue == 9)
                {
                    target = new Vector2(87.5f, 120);
                }
                else if (CardManager.cardsInDeckBlue == 10)
                {
                    target = new Vector2(112.5f, 120);
                }
                else if (CardManager.cardsInDeckBlue == 11)
                {
                    target = new Vector2(137.5f, 120);
                }
            }
            else
            {
                if (CardManager.cardsInDeckRed == 0)
                {
                    target = new Vector2(-137.5f, 120);
                }
                else if (CardManager.cardsInDeckRed == 1)
                {
                    target = new Vector2(-112.5f, 120);
                }
                else if (CardManager.cardsInDeckRed == 2)
                {
                    target = new Vector2(-87.5f, 120);
                }
                else if (CardManager.cardsInDeckRed == 3)
                {
                    target = new Vector2(-62.5f, 120);
                }
                else if (CardManager.cardsInDeckRed == 4)
                {
                    target = new Vector2(-37.5f, 120);
                }
                else if (CardManager.cardsInDeckRed == 5)
                {
                    target = new Vector2(-12.5f, 120);
                }
                else if (CardManager.cardsInDeckRed == 6)
                {
                    target = new Vector2(12.5f, 120);
                }
                else if (CardManager.cardsInDeckRed == 7)
                {
                    target = new Vector2(37.5f, 120);
                }
                else if (CardManager.cardsInDeckRed == 8)
                {
                    target = new Vector2(62.5f, 120);
                }
                else if (CardManager.cardsInDeckRed == 9)
                {
                    target = new Vector2(87.5f, 120);
                }
                else if (CardManager.cardsInDeckRed == 10)
                {
                    target = new Vector2(112.5f, 120);
                }
                else if (CardManager.cardsInDeckRed == 11)
                {
                    target = new Vector2(137.5f, 120);
                }
            }
            cardMaker = maker.GetComponent<cardCollection>();
            this.transform.SetParent(canvas.transform, false);
        }
    }

    private void Update()
    {
        if (arrived == true)
        {

        }
        else if (isInDeck == true && travel == true)
        {
            travel = false;
            arrived = true;
            Instantiate(this.gameObject);
            Destroy(this.gameObject);
        }
        else if (isInDeck)
        {
            t += Time.deltaTime / timeToReachTarget;
            this.gameObject.transform.localPosition = Vector2.Lerp(startPosition, target, t);

            if (putIn < 0)
            {
                travel = true;
            }
            else
            {
                putIn -= 1 * Time.deltaTime;
            }
        }
    }

    public void inOutDeck()
    {

        if (this.isInDeck == true)
        {
            cardMaker.possibleAmount = cardMaker.possibleAmount + 1;

            cardMaker.enoughLimit.SetActive(false);

            if (blueCard == true)
            {
                CardManager.cardsInDeckBlue--;
                deckMadeBlue = false;
            }
            else
            {
                CardManager.cardsInDeckRed--;
                deckMadeRed = false;
            }

            cardAddRemov.Play();

            Destroy(this.gameObject);
        }
        else
        {
            if (this.blueCard == true && CardManager.cardsInDeckBlue < 12)
            {
                if (possibleAmount > 0)
                {
                    isInDeck = true;

                    clone = (GameObject)Instantiate(this.gameObject);

                    clonedSelf = clone.GetComponent<cardCollection>();

                    clonedSelf.maker = this.gameObject;

                    possibleAmount--;

                    clonedSelf = null;

                    clone = null;

                    maker = null;

                    isInDeck = false;

                    if (possibleAmount == 0)
                    {
                        enoughLimit.SetActive(true);
                    }
                }
            }
            else if (blueCard == false && CardManager.cardsInDeckRed < 12)
            {
                if (possibleAmount > 0)
                {
                    isInDeck = true;

                    clone = (GameObject)Instantiate(this.gameObject);

                    clonedSelf = clone.GetComponent<cardCollection>();

                    clonedSelf.maker = this.gameObject;

                    possibleAmount--;

                    clonedSelf = null;

                    clone = null;

                    maker = null;

                    isInDeck = false;

                    if (possibleAmount == 0)
                    {
                        enoughLimit.SetActive(true);
                    }
                }
            }
        }

        /*if (CardManager.infoMode == true)
        {
            infoBox.SetActive(true);
            cardMan.displayedInfo.text = cardInfo.text;
        }*/
    }
}
