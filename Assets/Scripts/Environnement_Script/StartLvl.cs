using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLvl : MonoBehaviour
{
    public bool canActivate;
    public bool open = false;
    private void OnTriggerEnter(Collider other)
    {
        canActivate = true;
    }
    private void OnTriggerStay(Collider other)
    {
        MovePlayer test = other.GetComponent<MovePlayer>();
        if (test != null)
        {

            if (other.GetComponent<PlayerState>().isGrabing && canActivate && !open)
            {
                Debug.Log("activate");
                open = true;
                canActivate = false;
               // FindObjectOfType<AudioManager>().PlaySoundObject("LeverOn");
                test.StartCompter = true;

            }
            if (other.GetComponent<PlayerState>().isGrabing && open && canActivate)
            {
                Debug.Log("desactivate");
                open = false;
                canActivate = false;
                // FindObjectOfType<AudioManager>().PlaySoundObject("LeverOff");
                test.StartCompter = false;

            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        canActivate = false;
    }
}
