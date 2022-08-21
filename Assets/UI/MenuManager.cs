using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Button startButton;
    public Button settingsButton;
    public Button creditsButton;
    public Button quitButton;
    public Button controlsButton;
    public Button settingsBackButton;
    public Button creditsBackButton;
    public Button controlsBackButton;
    public GameObject settingsMenu;
    public GameObject creditsMenu;
    public GameObject controlsMenu;

    private void Start()
    {
        settingsMenu.SetActive(false);
        creditsMenu.SetActive(false);
        controlsMenu.SetActive(false);
    }

    public void QuitOnClick()
    {
        Debug.Log("Quit button pressed");
        Application.Quit();
    }
}
