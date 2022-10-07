using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    public bool loadLevel;
    public string levelName;

    // Update is called once per frame
    void Update()
    {
        if(loadLevel == true)
        {
            loadLevel = false;
            SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
        }
    }
}
