using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public bool startWhite;
    public bool endWhite;

    [SerializeField] private Image fadeImage;

    // Start is called before the first frame update
    void Start()
    {
        if(startWhite == true)
        {
            fadeImage.color = Color.white;
            StartCoroutine(SetToBlack());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SceneTransition()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void RestartTransition()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    IEnumerator SetToBlack()
    {
        yield return new WaitForSeconds(2.0f);
        fadeImage.color = Color.black;
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        if (endWhite == true)
            fadeImage.color = Color.white;
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        if(levelIndex != 15)
            SceneManager.LoadScene(levelIndex);
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}
