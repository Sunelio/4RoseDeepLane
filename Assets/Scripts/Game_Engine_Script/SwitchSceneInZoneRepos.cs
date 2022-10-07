using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SwitchSceneInZoneRepos : MonoBehaviour
{
    public PlayerState state;
    public GameObject spawnPoint;

    private void Start()
    {
        GameObject g = GameObject.Find("Player");
        state = g.GetComponent<PlayerState>();
        state.isDestroyBox = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            spawnPoint.SetActive(false);
            SceneManager.LoadScene(state.previousLevel + 1);
            state.isPositionLoad = true;
            ActivePlayer.activP = true;
        }
    }
}