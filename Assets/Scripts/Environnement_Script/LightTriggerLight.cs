using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTriggerLight : MonoBehaviour
{
    // FIELDS
    public GameObject nextLight;
    [HideInInspector]
    public bool isUsed;

    // Audio
    [SerializeField] private bool isNeon = false;
    private AudioManager audioManager;

    private void Awake()
    {
        // Get Audio Manager
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
            if (!isUsed) // Activates next light once
            {
                nextLight.SetActive(true);
                isUsed = true;
            }

            // Safe Zone
            test.StartCompter = false;
            test.deathCompter = test.initDeathCompter;

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

            // Play SFX : Shadows
            audioManager.PlaySFXPlayer("Shadow");
        }
    }

    private void OnDisable()
    {
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
