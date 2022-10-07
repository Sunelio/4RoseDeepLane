using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTriggerPositionZ : MonoBehaviour
{
    public PlayerState state;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            state.isPlayerTriggerCameraZ = true;
        }
    }
}