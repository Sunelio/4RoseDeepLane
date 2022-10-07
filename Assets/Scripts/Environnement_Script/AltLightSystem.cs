using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltLightSystem : MonoBehaviour
{
    // Serialize Fields
    [SerializeField] private float altTime = 2f;
    [SerializeField] Light[] lights;

    // Private Fields
    private Light[] playerLights;

    private void Awake()
    {
        playerLights = FindObjectOfType<MovePlayer>().gameObject.GetComponentsInChildren<Light>();
    }
    public IEnumerator Blink() // Deactivates all lights, wait altTime and then reactivates them
    {
        foreach(Light light in lights)
        {
            light.gameObject.SetActive(false);
        }

        foreach (Light playerLight in playerLights)
        {
            playerLight.gameObject.SetActive(false);
        }

        yield return new WaitForSeconds(altTime);

        foreach(Light light in lights)
        {
            light.gameObject.SetActive(true);
        }

        foreach (Light playerLight in playerLights)
        {
            playerLight.gameObject.SetActive(true);
        }
    }
}
