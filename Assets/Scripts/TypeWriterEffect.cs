using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using System;
// Typewriter effect source: https://gist.github.com/unitycoder/19625fed364a39cb278f

// Handles text displayment on briefing monologues
// Picks up parts of monologue from an array of TMP texts
// Shows buttons to continue and start mission
// If player hides the UI while text is playing, it will skip to the end
public class TypeWriterEffect : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI[] texts;
    public bool playOnStart = true;
    public float delayToStart = 0;
    public float delayBetweenChars = 0.125f;
    public float delayAfterPunctuation = 0.5f;
    public float delayAfterSentence = 1f;
    private string story;
    private float originDelayBetweenChars;
    private bool lastCharPunctuation = false;
    private char charComma;
    private char charPeriod;
    private char charEmpty;
    // Text colors
    Color colVisible = new Color(255,255,255,255);
    Color colHidden = new Color(255,255,255,0);
    // Button
    /*public GameObject continueButton;
    public GameObject startButton;*/
    // Text index
    public int textIndex = 0;
    // Misc
    private bool firstTime = false; // Hack to prevent text from disappearing when player leaves interaction collider
    void Awake() // Is run before OnEnable()
    {
        text = texts[0];
        originDelayBetweenChars = delayBetweenChars;

        charComma = Convert.ToChar(44);
        charPeriod = Convert.ToChar(46);
        charEmpty = Convert.ToChar(" ");//Convert.ToChar(255);
    }
    void Start()
    {
        if (playOnStart)
        {
            ChangeText(text.text, delayToStart);
        }
    }
    /*void OnEnable() // If the parent object of this script is not unabled in the editor beofre starting, this will run. Better to use Start()
    {
        if (playOnStart)
        {
            ChangeText(text.text, delayToStart);
        }
    }*/
    /*void OnDisable() // If player leaves the interaction collider, skip the text to the end
    {
        if(firstTime)
        {
            text.text = story;
            if(textIndex != texts.Length - 1)
                continueButton.SetActive(true);
            else
                startButton.SetActive(true);
        }
    }*/

    //Update text and start typewriter effect
    public void ChangeText(string textContent, float delayBetweenChars = 0f)
    {
        story = textContent;
        text.text = ""; //clean text
        Invoke("Start_PlayText", delayBetweenChars); //Invoke effect
    }
    public void Continue()
    {
        text.color = colHidden;
        //continueButton.SetActive(false);
        textIndex++; // each time we continue, the text index is incremented
        text = texts[textIndex];
        ChangeText(text.text, delayToStart);
    }

    public void Start_PlayText()
    {
        StartCoroutine(PlayText());
    }

    // This coroutine plays the text in "story" letter by letter
    IEnumerator PlayText()
    {
        firstTime = true;
        text.color = colVisible;
        foreach (char c in story)
        {
            delayBetweenChars = originDelayBetweenChars;

            if (lastCharPunctuation)  //If previous character was a comma/period, pause typing
            {
                yield return new WaitForSeconds(delayBetweenChars = delayAfterPunctuation);
                lastCharPunctuation = false;
            }

            if ( c == charEmpty || c == charComma || c == charPeriod  )
            {
            lastCharPunctuation = true;
            }

            text.text += c;
            yield return new WaitForSeconds(delayBetweenChars);
        }
        /*if(textIndex != texts.Length - 1)
            continueButton.SetActive(true);
        else
            startButton.SetActive(true);*/
        
        yield return new WaitForSeconds(delayAfterSentence);
        text.text = "";
        yield return null;
    }
    public void CallChangeText()
    {
        ChangeText(text.text, delayToStart);
    }
}