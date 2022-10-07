using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    [Tooltip("Switch Scene")]
    public PlayerState state;
    public GameObject spawnPoint;

    private void Start()
    {
        GameObject g = GameObject.Find("Player");
        state = g.GetComponent<PlayerState>();
    }

    public void OnTriggerEnter(Collider other)
    {
        MovePlayer player = other.GetComponent<MovePlayer>();
        if (player)
        {
            spawnPoint.SetActive(false);
            state.previousLevel = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene("SCN_ZoneRepos");
            state.isPositionLoad = true;
            state.isDestroyBox = true;
        }
    }
}
