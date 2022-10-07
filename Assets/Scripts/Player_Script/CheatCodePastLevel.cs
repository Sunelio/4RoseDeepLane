using UnityEngine;
using UnityEngine.SceneManagement;

public class CheatCodePastLevel : MonoBehaviour
{
    public Scene scene;
    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    public void PastLevel()
    {
        switch (scene.name)
        {
            case "SCN_Cave":
                SceneManager.LoadScene("SCN_SDB");
                break;
            case "SCN_Chambre":
                SceneManager.LoadScene("SCN_Cuisine");
                break;
            case "SCN_Cuisine":
                SceneManager.LoadScene("SCN_Tutorial");
                break;
            case "SCN_SDB":
                SceneManager.LoadScene("SCN_Chambre");
                break;
            case "SCN_Coeur":
                SceneManager.LoadScene("SCN_Cave");
                break;
            default:
                break;
        }
    }
}
