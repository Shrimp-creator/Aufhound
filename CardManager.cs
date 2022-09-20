using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class CardManager : MonoBehaviour
{
    public AudioSource buttonSound;

    public GameObject blueCards;

    public List<GameObject> blueDeck = new List<GameObject>();

    public GameObject redCards;

    public List<GameObject> redDeck = new List<GameObject>();

    public GameObject deck1;

    public GameObject deck2;

    public GameObject carl;
    public GameObject gDuo;
    public GameObject gBlock;
    public GameObject buffG;
    public GameObject gobru;
    public GameObject maddox;
    public GameObject mKing;
    public GameObject bog;
    public GameObject tooth;
    public GameObject gSpy;
    public GameObject gRider;
    public GameObject sling;

    public GameObject hank;
    public GameObject rang;
    public GameObject drago;
    public GameObject skulls;
    public GameObject swing;
    public GameObject sea;
    public GameObject fred;
    public GameObject peek;
    public GameObject zomb;
    public GameObject gRun;
    public GameObject theCount;
    public GameObject kek;

    public string GameScene;

    public GameObject CardMan;

    public int nextSceneIndex;

    public bool load;

    public GameObject eventManager;

    public bool blueMode;

    public static int elementalTag;

    public static int cardsInDeckBlue;
    public static int cardsInDeckRed;

    public GameObject goblinsBlue;
    public GameObject undeadBlue;

    public GameObject goblinsRed;
    public GameObject undeadRed;

    public GameObject cardsAndDecks;
    public GameObject mainMenu;

    public GameObject goblinTabObject;
    public GameObject undeadTabObject;

    public int currentTab;
    public int blueType;
    public int redType;

    public GameObject cardInspector;

    public int inspectorTab;

    public GameObject goblinInspector;
    public GameObject undeadInspector;
    public GameObject goblinInTab;
    public GameObject undeadInTab;

    public List<inspector> goblinCards = new List<inspector>();
    public List<inspector> undeadCards = new List<inspector>();

    public string tabTypeBlue;
    public string tabTypeRed;

    public bool deckCheck;

    public AudioMixer musicMixer;

    public GameObject options;

    public Slider musicSlider;
    public Slider soundSlider;

    public bool visitedRedMode;

    public void Start()
    {
        cardsInDeckBlue = 0;
        cardsInDeckRed = 0;

        //System.IO.File.Delete(Application.persistentDataPath + "/deck.help");

        if (System.IO.File.Exists(Application.persistentDataPath + "/deck.help"))
        {
            deckSaver data = deckLoader.LoadDeck();

            tabTypeBlue = data.tabBlue;
            tabTypeRed = data.tabRed;

            cardsAndDecks.SetActive(true);

            redCards.SetActive(true);
            deck2.SetActive(true);

            if (data.tabBlue == "Undead")
            {
                goblinsBlue.SetActive(false);
                undeadBlue.SetActive(true);
            }
            else if (data.tabBlue == "Goblin")
            {
                goblinsBlue.SetActive(true);
                undeadBlue.SetActive(false);
            }

            if (data.tabRed == "Undead")
            {
                goblinsRed.SetActive(false);
                undeadRed.SetActive(true);
            }
            else if (data.tabRed == "Goblin")
            {
                goblinsRed.SetActive(true);
                undeadRed.SetActive(false);
            }

            deckCheck = true;
        }

        options.SetActive(true);
        loadSavedVolumes();
    }

    public void toOptions()
    {
        buttonSound.Play();

        mainMenu.SetActive(false);
        cardsAndDecks.SetActive(false);
        options.SetActive(true);
    }

    public void optionsToMenu()
    {
        buttonSound.Play();

        options.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void musicVolume(float volume)
    {
        musicMixer.SetFloat("Music Mixer", volume);

        PlayerPrefs.SetFloat("MusicValue", volume);
    }

    public void soundVolume(float volume)
    {
        musicMixer.SetFloat("Sound Mixer", volume);

        PlayerPrefs.SetFloat("SoundValue", volume);
    }

    public void loadSavedVolumes()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicValue");
        soundSlider.value = PlayerPrefs.GetFloat("SoundValue");
    }

    public void putCardsInArray()
    {
        buttonSound.Play();

        if (System.IO.File.Exists(Application.persistentDataPath + "/deck.help"))
        {
            if (load == false)
            {
                load = true;

                StartCoroutine(ChangeScene());
            }
        }
    }

    public void deckBuilder()
    {
        buttonSound.Play();

        if (deckCheck == true)
        {
            redCards.SetActive(false);
            deck2.SetActive(false);

            deckCheck = false;
        }

        mainMenu.SetActive(false);
        options.SetActive(false);
        cardsAndDecks.SetActive(true);
    }

    public void backToDeck()
    {
        buttonSound.Play();

        cardInspector.SetActive(false);
        cardsAndDecks.SetActive(true);

        if (inspectorTab == 0)
        {
            foreach (inspector card in goblinCards)
            {
                card.isChosen = false;
                card.t = 0;
                card.mySign1.gameObject.transform.localPosition = card.startPosition1;
                card.mySign2.gameObject.transform.localPosition = card.startPosition2;
            }
        }
        else if (inspectorTab == 1)
        {
            foreach (inspector card in undeadCards)
            {
                card.isChosen = false;
                card.t = 0;
                card.mySign1.gameObject.transform.localPosition = card.startPosition1;
                card.mySign2.gameObject.transform.localPosition = card.startPosition2;
            }
        }
    }

    public void uniqueCardInfos()
    {
        buttonSound.Play();

        cardInspector.SetActive(true);
        cardsAndDecks.SetActive(false);
    }

    public void backToMenu()
    {
        buttonSound.Play();

        if (deck1.transform.childCount == 12 && deck2.transform.childCount == 12)
        {
            deckLoader.SaveDeck(this);
        }

        cardsAndDecks.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void quit()
    {
        buttonSound.Play();

        Application.Quit();
    }

    public void goblinCollection()
    {
        if (deckCheck == false)
        {
            buttonSound.Play();
        }

        if (inspectorTab != 0)
        {
            foreach (inspector card in undeadCards)
            {
                card.isChosen = false;
                card.t = 0;
                card.mySign1.gameObject.transform.localPosition = card.startPosition1;
                card.mySign2.gameObject.transform.localPosition = card.startPosition2;
            }

            undeadInTab.transform.localPosition = new Vector2(-110, -142.5f);
            undeadInspector.SetActive(false);
            goblinInTab.transform.localPosition = new Vector2(-155, -170.5f);
            goblinInspector.SetActive(true);

            inspectorTab = 0;
        }
    }

    public void undeadCollection()
    {
        if (deckCheck == false)
        {
            buttonSound.Play();
        }

        if (inspectorTab != 1)
        {
            foreach (inspector card in goblinCards)
            {
                card.isChosen = false;
                card.t = 0;
                card.mySign1.gameObject.transform.localPosition = card.startPosition1;
                card.mySign2.gameObject.transform.localPosition = card.startPosition2;
            }

            goblinInTab.transform.localPosition = new Vector2(-155, -142.5f);
            goblinInspector.SetActive(false);
            undeadInTab.transform.localPosition = new Vector2(-110, -170.5f);
            undeadInspector.SetActive(true);

            inspectorTab = 1;
        }
    }

    public void switchBlue()
    {
        if (deckCheck == false)
        {
            buttonSound.Play();
        }

        if (blueMode == false)
        {
            blueMode = true;

            redCards.SetActive(false);

            deck2.SetActive(false);

            blueCards.SetActive(true);

            deck1.SetActive(true);

            if (blueType == 0)
            {
                goblinTabObject.transform.localPosition = new Vector2(95, -170.5f);
                undeadTabObject.transform.localPosition = new Vector2(140, -142.5f);
                currentTab = 0;
            }
            else if (blueType == 1)
            {
                goblinTabObject.transform.localPosition = new Vector2(95, -142.5f);
                undeadTabObject.transform.localPosition = new Vector2(140, -170.5f);
                currentTab = 1;
            }

            goblinTabObject.GetComponent<tabAutoPress>().amRed = false;
            undeadTabObject.GetComponent<tabAutoPress>().amRed = false;

            goblinTabObject.GetComponent<tabAutoPress>().amBlue = true;
            undeadTabObject.GetComponent<tabAutoPress>().amBlue = true;

            goblinTabObject.GetComponent<tabAutoPress>().Start();
            undeadTabObject.GetComponent<tabAutoPress>().Start();
        }
    }

    public void switchRed()
    {
        if (deckCheck == false)
        {
            buttonSound.Play();
        }

        if (blueMode == true)
        {
            blueMode = false;

            blueCards.SetActive(false);

            deck1.SetActive(false);

            redCards.SetActive(true);

            deck2.SetActive(true);

            if (redType == 0)
            {
                goblinTabObject.transform.localPosition = new Vector2(95, -170.5f);
                undeadTabObject.transform.localPosition = new Vector2(140, -142.5f);
                currentTab = 0;
            }
            else if (redType == 1)
            {
                goblinTabObject.transform.localPosition = new Vector2(95, -142.5f);
                undeadTabObject.transform.localPosition = new Vector2(140, -170.5f);
                currentTab = 1;
            }

            goblinTabObject.GetComponent<tabAutoPress>().amBlue = false;
            undeadTabObject.GetComponent<tabAutoPress>().amBlue = false;

            goblinTabObject.GetComponent<tabAutoPress>().amRed = true;
            undeadTabObject.GetComponent<tabAutoPress>().amRed = true;

            goblinTabObject.GetComponent<tabAutoPress>().Start();
            undeadTabObject.GetComponent<tabAutoPress>().Start();

            visitedRedMode = true;
        }
    }

    public void goblinTab()
    {
        if (deckCheck == false)
        {
            buttonSound.Play();
        }

        if (currentTab != 0)
        {
            if (blueMode == true)
            {
                foreach (Transform child in deck1.transform)
                {
                    cardCollection card = child.gameObject.GetComponent<cardCollection>();

                    card.cardMaker.possibleAmount = card.cardMaker.possibleAmount + 1;

                    card.cardMaker.enoughLimit.SetActive(false);

                    cardsInDeckBlue--;

                    Destroy(child.gameObject);
                }
                undeadTabObject.transform.localPosition = new Vector2(140, -142.5f);
                undeadBlue.SetActive(false);
                goblinTabObject.transform.localPosition = new Vector2(95, -170.5f);
                goblinsBlue.SetActive(true);
                tabTypeBlue = "Goblin";
                cardCollection.deckMadeBlue = false;
                blueType = 0;
            }
            else
            {
                if (visitedRedMode == true)
                {
                    foreach (Transform child in deck2.transform)
                    {
                        cardCollection card = child.gameObject.GetComponent<cardCollection>();

                        card.cardMaker.possibleAmount = card.cardMaker.possibleAmount + 1;

                        card.cardMaker.enoughLimit.SetActive(false);

                        cardsInDeckRed--;

                        Destroy(child.gameObject);
                    }
                }
                undeadTabObject.transform.localPosition = new Vector2(140, -142.5f);
                undeadRed.SetActive(false);
                goblinTabObject.transform.localPosition = new Vector2(95, -170.5f);
                goblinsRed.SetActive(true);
                tabTypeRed = "Goblin";
                cardCollection.deckMadeRed = false;
                redType = 0;
            }
            currentTab = 0;
        }
    }

    public void undeadTab()
    {
        if (deckCheck == false)
        {
            buttonSound.Play();
        }

        if (currentTab != 1)
        {
            if (blueMode == true)
            {
                foreach (Transform child in deck1.transform)
                {
                    cardCollection card = child.gameObject.GetComponent<cardCollection>();

                    card.cardMaker.possibleAmount = card.cardMaker.possibleAmount + 1;

                    card.cardMaker.enoughLimit.SetActive(false);

                    cardsInDeckBlue--;

                    Destroy(child.gameObject);
                }
                goblinTabObject.transform.localPosition = new Vector2(95, -142.5f);
                goblinsBlue.SetActive(false);
                undeadTabObject.transform.localPosition = new Vector2(140, -170.5f);
                undeadBlue.SetActive(true);
                tabTypeBlue = "Undead";
                cardCollection.deckMadeBlue = false;
                blueType = 1;
            }
            else
            {
                if (visitedRedMode == true)
                {
                    foreach (Transform child in deck2.transform)
                    {
                        cardCollection card = child.gameObject.GetComponent<cardCollection>();

                        card.cardMaker.possibleAmount = card.cardMaker.possibleAmount + 1;

                        card.cardMaker.enoughLimit.SetActive(false);

                        cardsInDeckRed--;

                        Destroy(child.gameObject);
                    }
                }
                goblinTabObject.transform.localPosition = new Vector2(95, -142.5f);
                goblinsRed.SetActive(false);
                undeadTabObject.transform.localPosition = new Vector2(140, -170.5f);
                undeadRed.SetActive(true);
                tabTypeRed = "Undead";
                cardCollection.deckMadeRed = false;
                redType = 1;
            }
            currentTab = 1;
        }
    }

    IEnumerator ChangeScene()
    {
        SceneManager.LoadScene(nextSceneIndex, LoadSceneMode.Single);

        Scene nextScene = SceneManager.GetSceneAt(0);

        eventManager.SetActive(false);

        yield return null;

        SceneManager.UnloadSceneAsync(nextSceneIndex - 1);
    }
}
