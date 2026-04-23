using Ink.Runtime;
using UnityEngine;
// using System;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class PhoneDialogue : MonoBehaviour
{
    public phone_screen phone_screen_script;
    public TextAsset inkAsset;
    public TMP_Text line;
    public Button buttonPrefab = null;
    public bool dialogueOn = false;
    public Transform choicesContainer;
    public Transform textContainer;
    public GameObject textItemPrefab;

    public int notifications = 0;
    public GameObject notificationBanner;
    public GameObject notificationBackground;

    private int dialogueState = 0;
    private int DIALOGUE_OFF = 0;
    private int WAIT_CONFIRM = 1;
    private int WAIT_CHOICE = 2;
    private int CHOICE_DISPLAYED = 3;


    Story story;

    void Awake()
    {
        LoadDialogues();
    }

    void Start()
    {
        StartDialogue();
    }

    // public void StartGame()
    // {
    //     StartDialogue();
    // }

    void LoadDialogues()
    {
        story = new Story(inkAsset.text);
    }

    public void StartDialogue()
    {
        Debug.Log("dialogue started");
        story.ChoosePathString("start");
        StartCoroutine(ContinueDialogue());

    }

    IEnumerator ContinueDialogue()
    {
        RemoveChoices();
        if (story.canContinue || story.currentChoices.Count > 0)
        {
            Debug.Log("continuing story");
            bool lineDisplayed = false;
            story.Continue();

            float delay = 5;
            dialogueState = DIALOGUE_OFF;
            yield return new WaitForSeconds(delay);
            dialogueState = WAIT_CONFIRM;
            if (story.currentText != "")
            {
                DisplayLine(story.currentText);
                lineDisplayed = true;
            }
            if (story.currentChoices.Count > 0 && story.currentText != "")
            {
                dialogueState = WAIT_CHOICE;
                lineDisplayed = true;
            }

            if (!lineDisplayed && !story.canContinue && story.currentChoices.Count == 0)
            {
                StartCoroutine(EndDialogue());
            }

            if (dialogueState == WAIT_CHOICE)
            {
                Debug.Log("displaying choices");
                DisplayChoices();
            }
        }

        else if (dialogueState == WAIT_CHOICE)
        {
            Debug.Log("displaying choices");
            DisplayChoices();
        }

        else
        {
            StartCoroutine(EndDialogue());
        }

    }

    IEnumerator EndDialogue()
    {
        dialogueOn = false;
        Debug.Log("Dialogue has ended");
        yield return new WaitForSeconds(1f);
        Debug.Log("entering end screen");
        StartCoroutine(Deactivate("EndText", false));
        StartCoroutine(Activate("EndScreen"));

    }

    void OnClickChoiceButton(Choice choice)
    {

        story.ChooseChoiceIndex(choice.index);
        //DisplayLine(choice.text);
        //StartCoroutine(TypingDelay());
        RemoveChoices();
        StartCoroutine(ContinueDialogue());
    }

    // IEnumerator TypingDelay()
    // {
    //     RemoveChoices();
    //     yield return new WaitForSeconds(1f);
    //     Debug.Log("typing delay call");
    //     StartCoroutine(ContinueDialogue());
    // }


    void DisplayLine(string txt)
    {
        notifications++;
        TMP_Text notificationText = notificationBackground.GetComponentInChildren<TMP_Text>();
        if (notifications == 1)
        {
            notificationText.text = notifications + " new message";
        }
        else
        {
            notificationText.text = notifications + " new messages";
        }
        Debug.Log("displaying line");
        txt = txt.Trim();

        // line.text += "\n" + txt;
        // dialogueState = WAIT_CONFIRM;
        txt = txt.Trim();
        GameObject newTextObject = Instantiate(textItemPrefab, textContainer);
        TextMeshProUGUI textComponent = newTextObject.GetComponentInChildren<TextMeshProUGUI>();
        List<string> tags = story.currentTags;
        textComponent.text = txt;
    }

    void DisplayChoices()
    {
        dialogueState = CHOICE_DISPLAYED;
        choicesContainer.gameObject.SetActive(true);
        if (story.currentChoices.Count > 0)
        {

            for (int i = 0; i < story.currentChoices.Count; i++)
            {
                Choice choice = story.currentChoices[i];
                Button button = CreateChoice(choice.text.Trim());

                // Tell the button what to do when we press it
                button.onClick.AddListener(delegate
                {
                    OnClickChoiceButton(choice);
                });


                //select the first button
                if (i == 0)
                {
                    EventSystem.current.firstSelectedGameObject = button.gameObject;
                    EventSystem.current.SetSelectedGameObject(button.gameObject);
                }
            }
        }
    }

    // Creates a button showing the choice text
    Button CreateChoice(string text)
    {
        // Creates the button from a prefab
        Button choice = Instantiate(buttonPrefab) as Button;
        choice.transform.SetParent(choicesContainer, false);

        // Gets the text from the button prefab
        TMP_Text choiceText = choice.GetComponentInChildren<TMP_Text>();
        choiceText.text = text;

        return choice;
    }

    // Destroys all the children of this gameobject (all the UI)
    void RemoveChoices()
    {

        int childCount = choicesContainer.childCount;
        for (int i = childCount - 1; i >= 0; --i)
        {
            GameObject.Destroy(choicesContainer.GetChild(i).gameObject);
        }

        choicesContainer.gameObject.SetActive(false);
    }



    private void Update()
    {
        // set notifs back to zero after phone is opened and remove notification banner
        if (phone_screen_script.is_open == true)
        {
            Debug.Log("reset notifications");
            notificationBackground.SetActive(false);
            notifications = 0;
        }

        if (phone_screen_script.is_open == false && phone_screen_script.is_moving == false)
        {
            notificationBackground.SetActive(true);
            if (notifications > 0)
            {
                notificationBanner.SetActive(true);
            }

            else
            {
                notificationBanner.SetActive(false);
            }
        }

        if (dialogueState == CHOICE_DISPLAYED)
        {
            if (EventSystem.current.currentSelectedGameObject == null)
            {
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(EventSystem.current.firstSelectedGameObject);
            }
        }

        if (story.canContinue && dialogueState != DIALOGUE_OFF && dialogueState != CHOICE_DISPLAYED && dialogueState != WAIT_CHOICE)
        {
            Debug.Log("update call");
            StartCoroutine(ContinueDialogue());
        }


        // else if (Input.GetKeyDown(KeyCode.Return))
        // {
        //     //dialogue is on but not on choices and not while typing: go to the next state
        //     if (story.canContinue && dialogueState != DIALOGUE_OFF && dialogueState != CHOICE_DISPLAYED)
        //     {
        //         StartCoroutine(ContinueDialogue());
        //     }

        // }
    }

    public IEnumerator Activate(string id)
    {
        Debug.Log("activating something");
        Transform[] transforms = FindObjectsByType<Transform>(FindObjectsInactive.Include, FindObjectsSortMode.None);

        foreach (Transform t in transforms)
        {
            if (t.name == id)
            {
                t.gameObject.SetActive(true);
                //yield return new WaitForSeconds(0.001f);
                SpriteRenderer spriteRenderer = t.GetComponent<SpriteRenderer>();
                Image image = t.GetComponent<Image>();
                RawImage rawImage = t.GetComponent<RawImage>();
                if (rawImage != null)
                {
                    float alphaVal = rawImage.color.a;
                    Color tmp = rawImage.color;

                    while (rawImage.color.a < 255)
                    {
                        alphaVal += 0.005f;
                        tmp.a = alphaVal;
                        rawImage.color = tmp;

                        yield return new WaitForSeconds(0.05f);
                    }
                }

                if (image != null)
                {
                    float alphaVal = image.color.a;
                    Color tmp = image.color;

                    while (image.color.a < 255)
                    {
                        alphaVal += 0.01f;
                        tmp.a = alphaVal;
                        image.color = tmp;

                        yield return new WaitForSeconds(0.05f); // update interval
                    }
                }

                if (spriteRenderer != null)
                {
                    float alphaVal = spriteRenderer.color.a;
                    Color tmp = spriteRenderer.color;

                    while (spriteRenderer.color.a < 255)
                    {
                        alphaVal += 0.01f;
                        tmp.a = alphaVal;
                        spriteRenderer.color = tmp;

                        yield return new WaitForSeconds(0.05f); // update interval
                    }
                }
            }
        }
    }

    public IEnumerator Deactivate(string id, bool isFade)
    {
        GameObject obj = GameObject.Find(id);
        if (obj == null)
        {
            Debug.LogWarning("Warning: Dectivation failed. I couldn't find a game object named " + id);
        }

        else if (isFade == true)
        {
            SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();

            if (spriteRenderer == null)
            {
                TMP_Text[] allText = GetComponentsInChildren<TMP_Text>();
                Image[] allImages = GetComponentsInChildren<Image>();
                SpriteRenderer[] allSpriteRenderers = GetComponentsInChildren<SpriteRenderer>();

                foreach (SpriteRenderer sr in allSpriteRenderers)
                {
                    float spriteAlphaVal = sr.color.a;
                    Color spritetmp = sr.color;

                    while (sr.color.a > 0)
                    {
                        spriteAlphaVal -= 0.01f;
                        spritetmp.a = spriteAlphaVal;
                        sr.color = spritetmp;

                        yield return new WaitForSeconds(0.05f); // update interval
                    }
                }

                foreach (Image image in allImages)
                {
                    float imageAlphaVal = image.color.a;
                    Color imagetmp = image.color;

                    while (image.color.a > 0)
                    {
                        imageAlphaVal -= 0.01f;
                        imagetmp.a = imageAlphaVal;
                        image.color = imagetmp;

                        yield return new WaitForSeconds(0.05f); // update interval
                    }
                }

                foreach (TMP_Text text in allText)
                {
                    float textAlphaVal = text.color.a;
                    Color texttmp = text.color;

                    while (text.color.a > 0)
                    {
                        textAlphaVal -= 0.01f;
                        texttmp.a = textAlphaVal;
                        text.color = texttmp;

                        yield return new WaitForSeconds(0.05f); // update interval
                    }
                }
            }

            else if (spriteRenderer != null)
            {
                float alphaVal = spriteRenderer.color.a;
                Color tmp = spriteRenderer.color;

                while (spriteRenderer.color.a > 0)
                {
                    alphaVal -= 0.01f;
                    tmp.a = alphaVal;
                    spriteRenderer.color = tmp;

                    yield return new WaitForSeconds(0.05f); // update interval
                }

            }

            obj.SetActive(false);
        }
        else
        {
            Debug.Log("deactivating");
            obj.SetActive(false);
        }
    }

}