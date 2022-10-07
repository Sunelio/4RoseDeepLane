using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPPlayerNextRoomCellar : MonoBehaviour
{
    // References
    //[SerializeField] private GameObject player;
    [SerializeField] private GameObject spawnPos;
    [SerializeField] private AltLightSystem altLightSystem;
    [SerializeField] private RedLightZone redLightZone;
    private void OnTriggerEnter(Collider other)
    {
        MovePlayer test = other.GetComponent<MovePlayer>();
        if(test != null) // TP Player & Blink
        {
            test.transform.position = spawnPos.transform.position;
            redLightZone.isIn = false;
            StartCoroutine(altLightSystem.Blink());
        }
    }
}
