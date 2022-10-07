using UnityEngine;
using UnityEngine.SceneManagement;

public class CheatCodeNextLevel : MonoBehaviour
{
    public Scene scene;
    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    public void NextLevel()
    {
        switch (scene.name)
        {
            case "SCN_Cave":
                SceneManager.LoadScene("SCN_Coeur");
                break;
            case "SCN_Chambre":
                SceneManager.LoadScene("SCN_SDB");
                break;
            case "SCN_Cuisine":
                SceneManager.LoadScene("SCN_Chambre");
                break;
            case "SCN_SDB":
                SceneManager.LoadScene("SCN_Cave");
                break;
            case "SCN_Tutorial":
                SceneManager.LoadScene("SCN_Cuisine");
                break;
            default:
                break;
        }
    }
}
