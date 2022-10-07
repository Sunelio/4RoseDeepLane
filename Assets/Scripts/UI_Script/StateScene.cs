using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneState
{
    MAINMENU,
    TUTORIAL,
    SETTINGS,
    CONTROLER,
}
public class StateScene : MonoBehaviour
{
    public SceneState sceneState;
    public Scene scene;

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        if(scene.name == "SCN_MainMenu")
        {
            sceneState = SceneState.MAINMENU;
        }

        if (scene.name == "SCN_Settings")
        {
            sceneState = SceneState.SETTINGS;
        }

        if (scene.name == "SCN_Controls")
        {
            sceneState = SceneState.CONTROLER;
        }

        if (scene.name == "SCN_Tutorial")
        {
            sceneState = SceneState.TUTORIAL;

        }


    }
}
