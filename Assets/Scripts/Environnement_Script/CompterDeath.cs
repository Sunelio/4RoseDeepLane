using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompterDeath : MonoBehaviour
{
    public int deathValue;
    private MovePlayer player;
    private AudioManager audioManager;
    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        player = other.GetComponent<MovePlayer>();
        if(player != null)
        {
            

            player.deathCompter = deathValue;
            player.StartCompter = true;
            audioManager.PlaySFXPlayer("Shadow");



        }

    }
    private void OnTriggerExit(Collider other)
    {
        player = other.GetComponent<MovePlayer>();
        if (player != null)
        {
            player.StartCompter = false;
            player.deathCompter = deathValue;
            audioManager.StopSFXPlayer("Shadow");
        }
        
    }

}
