using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrazyTalk : MonoBehaviour
{
    //public Crazy
    public Text ItTalks;
    public float SpeechDelay;
    //Dialogue
    private string Intro = "Can you see them traveller?";
    private bool ReadText = false;

    //Responses
    [HideInInspector]
    public bool Responded = false;
    [HideInInspector]
    public bool Answer;

    //Responses to choice
    public Button Yes;
    private string TheyKnow = "The memories of your \n fatalities must be painful.";
    public Button No;
    private string TheyAreButAPuppet = "Ah yes, \n you only look left and right.";

    //Final Line
    private bool HeRepeats = false;
    private string HeWatches = "They see a man in chains \n but it is I who is looking \n at someone who is not free";

    //Player triggers Crazy Person
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //start talking animation
        GetComponent<Animator>().SetBool("Visited", true);

        //start talking
        if (!HeRepeats)
            StartCoroutine(Dialogue());
        //keep saying this when triggered
        else
            StartCoroutine(RepeatedLine());
    }

    private IEnumerator Dialogue()
    {
        //Skip this if intro happened
        if (!ReadText)
        {
            for (int i = 0; i < Intro.Length + 1; i++)
            {
                //cycles through string 1 character at a time
                ItTalks.text = Intro.Substring(0, i);
                //delay next character
                yield return new WaitForSeconds(SpeechDelay);
            }
            ReadText = true;
            Yes.gameObject.SetActive(true);
            No.gameObject.SetActive(true);

        }
        if (Responded)
        {
            //clear speech
            ItTalks.text = "";

            //answered Yes
            if (Answer)
            {
                for (int i = 0; i < TheyKnow.Length + 1; i++)
                {
                    //cycles through string 1 character at a time
                    ItTalks.text = TheyKnow.Substring(0, i);
                    //delay next character
                    yield return new WaitForSeconds(SpeechDelay);
                }
            }
            if (!Answer)
            {
                for (int i = 0; i < TheyAreButAPuppet.Length + 1; i++)
                {
                    //cycle through string 1 character at a time
                    ItTalks.text = TheyAreButAPuppet.Substring(0, i);
                    //delay next character
                    yield return new WaitForSeconds(SpeechDelay);
                }
            }
            HeRepeats = true;
        }
        //stop animation
        GetComponent<Animator>().SetBool("Visited", false);
        yield return new WaitForSeconds(SpeechDelay);
    }
    private IEnumerator RepeatedLine()
    {
        //clear text
        ItTalks.text = "";
        for (int i = 0; i < HeWatches.Length + 1; i++)
        {
            //cycles through string 1 character at a time
            ItTalks.text = HeWatches.Substring(0, i);
            //delay next character
            yield return new WaitForSeconds(SpeechDelay);
        }
        //stop animation
        GetComponent<Animator>().SetBool("Visited", false);
    }
}
