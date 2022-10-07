using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVoice : MonoBehaviour
{
    private AudioManager audioManager;
    public string soundToPlay;
    private bool hasNotPlayed;
    private void Awake()
    {
        audioManager = FindObjectOfType <AudioManager> ();
        hasNotPlayed = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        MovePlayer player = other.GetComponent<MovePlayer>();
        if (player && hasNotPlayed)
        {
            audioManager.PlayVoice(soundToPlay);
            hasNotPlayed = false;
        }
    }
}
