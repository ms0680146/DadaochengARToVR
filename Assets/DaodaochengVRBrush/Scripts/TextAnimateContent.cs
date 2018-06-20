using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextAnimateContent : MonoBehaviour {

    //Time taken for each letter to appear (The lower it is, the faster each letter appear)
    public float letterPaused = 0.1f;
    //Message that will displays till the end that will come out letter by letter
    public string message;
    //Text for the message to display
    public Text textComp;
    public AudioSource TypeTextSound;

    // Use this for initialization
    void Start()
    {
        //Get text component
        textComp = GetComponent<Text>();
        //Message will display will be at Text
        message = textComp.text;
        //Set the text to be blank first
        textComp.text = "";
        StartCoroutine(WaitHead());

    }


    IEnumerator WaitHead()
    {
        yield return new WaitForSeconds(37f);
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        TypeTextSound.Play();
        //Split each char into a char array
        foreach (char letter in message.ToCharArray())
        {
            //Add 1 letter each
            textComp.text += letter;
            yield return 0;

            yield return new WaitForSeconds(letterPaused);
        }
        TypeTextSound.Stop();
    }


}
