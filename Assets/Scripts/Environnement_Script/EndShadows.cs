using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndShadows : MonoBehaviour
{
    private AudioManager audioManager;
    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        MovePlayer test = other.GetComponent<MovePlayer>();
        if(test != null)
        {
            test.StartCompter = false;

            // Stop shadow sound
            audioManager.StopSFXPlayer("Shadow");
        }
    }
}
