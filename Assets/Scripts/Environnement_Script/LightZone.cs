using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightZone : MonoBehaviour
{
    private bool isIn;
    private MovePlayer movePlayerScript;

    // Audio
    [SerializeField] private bool isNeon = false;
    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnEnable()
    {
        // Play SFX : On
        if (isNeon)
        {
            audioManager.PlaySoundObject("NeonOn");
        }
        else
        {
            audioManager.PlaySoundObject("ButtonOn");
            Debug.Log("LightOn");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        MovePlayer test = other.GetComponent<MovePlayer>();
        if (test != null)
        {
            test.StartCompter = false;
            test.deathCompter = test.initDeathCompter;

            movePlayerScript = test;

            isIn = true;

            // Stop Shadows sound & play Shadows End
            audioManager.StopSFXPlayer("Shadow");
            audioManager.PlaySFXPlayer("ShadowEnd");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        MovePlayer test = other.GetComponent<MovePlayer>();
        if (test != null)
        {
            test.StartCompter = true;
            isIn = false;

            // Play SFX : Shadows
            audioManager.PlaySFXPlayer("Shadow");
        }
    }

    private void OnDisable()
    {
        if (isIn)
        {
            movePlayerScript.StartCompter = true;
        }

        // Play SFX : Off
        if (isNeon)
        {
            audioManager.PlaySoundObject("NeonOff");
        }
        else
        {
            audioManager.PlaySoundObject("LightOff");
        }
    }
}
