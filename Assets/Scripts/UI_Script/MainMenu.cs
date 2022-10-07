using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{

    [Header("Navigation")]
    [Tooltip("Open Settings Menu")]
    public GameObject optionScreen;
    [Tooltip("Open Chapter selection Menu")]
    public GameObject chapterScreen;
    [Tooltip("Open Controller Menu")]
    public GameObject controllerScreen;

    [Header("Open Button")]
    [Tooltip("The first button displayed when you enter the settings screen")]
    public GameObject optionFirstButton;
    [Tooltip("The first button displayed when you enter the chapter selection screen")]
    public GameObject chapterFirstButton;
    [Tooltip("The first button displayed when you enter the controller screen")]
    public GameObject controllerFirstButton;

    [Header("Return Button")]
    [Tooltip("The button that is displayed when you return to the pause menu via the settings screen")]
    public GameObject closeOptionButton;
    [Tooltip("The button that is displayed when you return to the pause menu via the chapter selection screen")]
    public GameObject closeChapterButton;
    [Tooltip("The button that is displayed when you return to the pause menu via the contoller screen")]
    public GameObject closeControllerButton;

    [Header("Other")]
    [Tooltip("Switch Scene")]
    public string firstLevel;
    public AudioManager audioM;
    public PlayableDirector cinematique;

    private void Start()
    {
        audioM = FindObjectOfType<AudioManager>();
    }

    public void StartGame()
    {
        if (cinematique.time >= 11)
        {
            audioM.PlayUI("ClickUI");
            SceneManager.LoadScene(firstLevel);
            QualitySettings.vSyncCount = 1;
        }
    }

    public void OpenSettings2()
    {
        if (cinematique.time >= 11)
        {
            audioM.PlayUI("ClickUI");
            optionScreen.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(optionFirstButton);
        }

    }

    public void CloseSettings2()
    {
        if (cinematique.time >= 11)
        { 
            audioM.PlayUI("ClickUI");
        optionScreen.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(closeOptionButton);
            }

    }

    public void OpenController2()
    {
        if (cinematique.time >= 11)
        {
            audioM.PlayUI("ClickUI");
            controllerScreen.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(controllerFirstButton);
        }

    }

    public void CloseController2()
    {
        if (cinematique.time >= 11)
        {
            audioM.PlayUI("ClickUI");
            controllerScreen.SetActive(false);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(closeControllerButton);
        }

    }

    public void OpenChapterSelection2()
    {
        if (cinematique.time >= 11)
        {
            audioM.PlayUI("ClickUI");
            chapterScreen.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(chapterFirstButton);
        }

    }

    public void CloseChapterSelection2()
    {
        if (cinematique.time >= 11)
        {
            audioM.PlayUI("ClickUI");
            chapterScreen.SetActive(false);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(closeChapterButton);
        }

    }

    public void QuitGame()
    {
        if (cinematique.time >= 11)
        {
            audioM.PlayUI("ClickUI");
            Application.Quit();
            Debug.Log("Quitting");
        }
    }
}