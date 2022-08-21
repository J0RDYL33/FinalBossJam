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
    public string musicToPlay;

    private MusicManager musicObject;

    [SerializeField] private Image fadeImage;

    // Start is called before the first frame update
    void Start()
    {
        musicObject = FindObjectOfType<MusicManager>();
        if(startWhite == true)
        {
            fadeImage.color = Color.white;
            StartCoroutine(SetToBlack());
        }

        if (musicToPlay != "")
            musicObject.PlaySound(musicToPlay);
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
        Debug.Log(levelIndex);
        if (levelIndex != 16)
        {
            SceneManager.LoadScene(levelIndex);
        }
        else
        {
            Destroy(musicObject.gameObject);
            SceneManager.LoadScene(0);
        }
    }
}
