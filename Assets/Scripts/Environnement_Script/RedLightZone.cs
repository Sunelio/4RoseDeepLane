using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLightZone : MonoBehaviour
{
    private Light redLight;
    private GameObject objectToSet;
    public float fadeTime;
    private float timer = 0f;
    private float startIntensity;
    private float debug;
    private bool isFading = false;
    private MovePlayer movePlayerScript;

    [HideInInspector]
    public bool isIn = false;

    // Audio
    [SerializeField] private bool isNeon = false;
    private AudioManager audioManager;

    private void Awake()
    {
        //redLight = GetComponent<Light>();

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
        Debug.Log("is here");
        MovePlayer test = other.GetComponent<MovePlayer>();
        if (test != null)
        {
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
        Debug.Log("Exit");
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
            // Deactivate Red Light
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
