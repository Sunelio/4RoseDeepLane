using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverPlayerLights : MonoBehaviour
{
    // Inspector
    private Light[] lights;
    [SerializeField] private LeverSwitch lever;

    // Private
    private bool hasBeenUsed = false;

    private void Awake()
    {
        // Gets player light components
        lights = FindObjectOfType<MovePlayer>().gameObject.GetComponentsInChildren<Light>();
    }
    // Update is called once per frame
    void Update()
    {
        if(lever.open && !hasBeenUsed)
        {
            foreach(Light light in lights)
            {
                // Deactivates the light
                light.gameObject.SetActive(false);
            }

            hasBeenUsed = true;
        }
    }
}
