using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogTyper : MonoBehaviour
{
    public string sentence = "You think you can beat me that easily? \n\nI have control over time again!";
    //public string sentence = "Rewinding time so far,\n\nthe God ceases to exist.\n\nThe cultists will be a threat in the future.\n\nWill you be there?";
    public TextMeshProUGUI screenText;

    private LevelLoader loader;
    // Start is called before the first frame update
    void Start()
    {
        loader = FindObjectOfType<LevelLoader>();
        CallSentence();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CallSentence()
    {
        StartCoroutine(TypeSentence());
    }

    private IEnumerator TypeSentence()
    {
        screenText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            screenText.text += letter;
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(5);
        loader.SceneTransition();
    }
}
