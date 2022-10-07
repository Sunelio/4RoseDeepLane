using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    private PlayerState playerState;
    public GameObject[] lightManager;
    public LightTriggerLight[] LightsTrigger;
    public RedLightTriggerLight[] redLightsTrigger;

    private void Awake()
    {
        playerState = FindObjectOfType<PlayerState>();
    }
    private void Update()
    {
        
        if (playerState.isDead) // Reset Lights
        {
            foreach (GameObject light in lightManager)
            {
                light.SetActive(true);
            }

            foreach (LightTriggerLight lightTrigger in LightsTrigger)
            {
                lightTrigger.isUsed = false;
            }

            foreach (RedLightTriggerLight redLightTrigger in redLightsTrigger)
            {
                redLightTrigger.isUsed = false;
            }

        }
        
        
    }
}
