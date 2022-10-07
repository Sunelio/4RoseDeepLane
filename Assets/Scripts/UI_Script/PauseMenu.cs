using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class PauseMenu : MonoBehaviour
{
    [Header("Navigation")]
    [Tooltip("Open Pause Menu")]
    public GameObject pauseMenu;
    [Tooltip("Open Settings Menu")]
    public GameObject settingsScreen;
    [Tooltip("Open Controller Menu")]
    public GameObject controllerScreen;

    [Header("Open Button")]
    [Tooltip("The first button displayed when you enter the settings screen")]
    public GameObject optionFirstButton;
    [Tooltip("The first button displayed when you enter the controller screen")]
    public GameObject controllerFirstButton;

    [Header("Return Button")]
    [Tooltip("The button that is displayed when you return to the pause menu via the settings screen")]
    public GameObject closeOptionButton;
    [Tooltip("The button that is displayed when you return to the pause menu via the contoller screen")]
    public GameObject closeControllerButton;

    [Header("Other")]
    [Tooltip("Switch Scene")]
    public string mainMenu;
    [Tooltip("Script ref to Player State")]
    public PlayerState state;
    [Tooltip("Take Inputs System")]
    private Inputs actions;
    public GameObject player;

    private void Awake()
    {
        actions = new Inputs();
    }

    private void OnEnable()
    {
        actions.Enable();
    }

    private void OnDisable()
    {
        actions.Disable();
    }

    private void Start()
    {
        actions.UI.Pause.performed += _ => DeterminePause();
        GameObject g = GameObject.Find("Player");
        state = g.GetComponent<PlayerState>();
        player = GameObject.Find("Player");
    }

    private void DeterminePause()
    {
        if (state.isPaused)
        {
            ResumeGame();
        }
        else if (!state.isPaused && !state.selectionGravity)
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        AudioListener.pause = true;
        state.isPaused = true;
        pauseMenu.SetActive(true);
    }


    public void ResumeGame()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        state.isPaused = false;
        pauseMenu.SetActive(false);
    }

    public void OpenControlScene()
    {
        Time.timeScale = 0f;
        AudioListener.pause = true;
        state.isPaused = true;
        controllerScreen.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(controllerFirstButton);
    }

    public void CloseControlScene()
    {
        Time.timeScale = 0f;
        AudioListener.pause = true;
        state.isPaused = true;
        controllerScreen.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(closeControllerButton);

    }

    public void OpenSettingsScene()
    {
        Time.timeScale = 0f;
        AudioListener.pause = true;
        state.isPaused = true;
        settingsScreen.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(optionFirstButton);

    }

    public void CloseSettingsScene()
    {
        Time.timeScale = 0f;
        AudioListener.pause = true;
        state.isPaused = true;
        settingsScreen.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(closeOptionButton);

    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        state.isPaused = false;
        Destroy(player);
        SceneManager.LoadScene(mainMenu);
    }
}