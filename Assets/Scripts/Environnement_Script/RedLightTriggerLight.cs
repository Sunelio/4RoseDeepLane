using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLightTriggerLight : MonoBehaviour
{
    // FIELDS switch on next light
    public GameObject nextLight;
    private Light redLight;
    [HideInInspector]
    public bool isUsed;

    // FIELDS Red Light Behavior
    private GameObject objectToSet;
    public float fadeTime;
    private float timer = 0f;
    private float startIntensity;
    private float debug;
    private bool isFading = false;
    private bool isIn = false;
    private MovePlayer movePlayerScript;

    // Audio
    [SerializeField] private bool isNeon = false;
    private AudioManager audioManager;

    private void Awake()
    {
        // Parent Version
        redLight = transform.parent.GetComponent<Light>();
        objectToSet = transform.parent.gameObject;

        // Get starting intensity
        startIntensity = redLight.intensity;

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
            // Allows the light to fade
            isFading = true;

            // Fix bug upon deactivating the red light
            isIn = true;
            movePlayerScript = test;

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
            isIn = false;

            // Shadows
            test.StartCompter = true;

            // Play SFX : Shadows
            audioManager.PlaySFXPlayer("Shadow");
        }
    }

    private void Update()
    {
        if (redLight.intensity <= 0)
        {
            // Deactivates Red Light
            objectToSet.SetActive(false);
        }

        if (isFading)
        {
            // Fading
            timer += Time.deltaTime;
            redLight.intensity = Mathf.Lerp(startIntensity, 0f, timer / fadeTime);
            debug = redLight.intensity;
        }
    }

    private void OnDisable()
    {
        if (isIn)
        {
            movePlayerScript.StartCompter = true;
        }

        // Reset Light
        isFading = false;
        timer = 0f;
        redLight.intensity = startIntensity;

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
