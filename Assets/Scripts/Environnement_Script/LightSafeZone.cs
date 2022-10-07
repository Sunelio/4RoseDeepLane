using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSafeZone : MonoBehaviour
{
    private LightTimer lightTimerScript;

    private void Start()
    {
        //lightTimerScript = GameObject.FindGameObjectWithTag("LightTimer").GetComponent<LightTimer>();
        lightTimerScript = GameObject.Find("LightTimer").GetComponent<LightTimer>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lightTimerScript.deathTime = 4f;
        }
    }
}
