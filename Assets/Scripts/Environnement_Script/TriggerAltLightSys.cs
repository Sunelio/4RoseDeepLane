using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAltLightSys : MonoBehaviour
{
    // References
    [SerializeField] AltLightSystem altLightSystem;

    private void OnTriggerEnter(Collider other)
    {
        MovePlayer test = other.GetComponent<MovePlayer>();
        if(test != null)
        {
            StartCoroutine(altLightSystem.Blink());
        }
    }
}
