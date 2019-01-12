using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrazyTalk : MonoBehaviour
{
    public Text ItTalks;
    public float TalkSpeed;
    private string introText = "Can you see them traveller?";
    private string nextIntroText = "They are watching us.";
    private string finalIntroText = "They are CONTROLLING you";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //start talking animation
        StartCoroutine(Introduction());
        GetComponent<Animator>().SetBool("Visited", true);
        StartCoroutine(Introduction());
    }

    private IEnumerator Introduction()
    {
        for (int i = 0; i < introText.Length; i++)
        {
            //cycles through string 1 character at a time
            ItTalks.text = introText.Substring(0, i);
            yield return new WaitForSeconds(TalkSpeed);
        }
        for (int i = 0; i < nextIntroText.Length; i++)
        {
            ItTalks.text = introText.Substring(0, i);
            yield return new WaitForSeconds(TalkSpeed);
        }
        for (int i = 0; i < finalIntroText.Length; i++)
        {
            ItTalks.text = introText.Substring(0, i);
            yield return new WaitForSeconds(TalkSpeed);
        }
    }
}
