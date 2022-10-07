using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixCameraZ : MonoBehaviour
{
    public PlayerState state;


    private void Start()
    {
        GameObject g = GameObject.Find("Player");
        state = g.GetComponent<PlayerState>();
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            state.isFixedZCamera = true;    
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            state.isFixedZCamera = false;
        }
    }
}
