using UnityEngine;
using UnityEngine.SceneManagement;

public class CheatCodeRestartLevel : MonoBehaviour
{
    public Scene scene;
    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }
    
    public void Restart()
    {
        switch (scene.name)
        {
            case "SCN_Testing Eliot":
                SceneManager.LoadScene(scene.name);
                break;
            case "SCN_Cave":
                SceneManager.LoadScene(scene.name);
                break;
            case "SCN_Chambre":
                SceneManager.LoadScene(scene.name);
                break;
            case "SCN_Coeur":
                SceneManager.LoadScene(scene.name);
                break;
            case "SCN_Cuisine":
                SceneManager.LoadScene(scene.name);
                break;
            case "SCN_SDB":
                SceneManager.LoadScene(scene.name);
                break;
            case "SCN_Tutorial":
                SceneManager.LoadScene(scene.name);
                break;
            case "SCN_Zone Repos":
                SceneManager.LoadScene(scene.name);
                break;
            default:
                break;
        }
    }
}
