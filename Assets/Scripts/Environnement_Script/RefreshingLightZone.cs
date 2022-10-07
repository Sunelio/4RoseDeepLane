using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshingLightZone : MonoBehaviour
{
    private bool isIn;
    private MovePlayer movePlayerScript;
    private void OnTriggerEnter(Collider other)
    {
        MovePlayer test = other.GetComponent<MovePlayer>();
        if (test != null)
        {
            movePlayerScript = test;
            isIn = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (isIn)
        {
            movePlayerScript.StartCompter = false;
            movePlayerScript.deathCompter = movePlayerScript.initDeathCompter;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        MovePlayer test = other.GetComponent<MovePlayer>();
        if (test != null)
        {
            test.StartCompter = true;
            isIn = false;
        }
        Debug.Log("Dying");
    }

    private void OnDisable()
    {
        if (isIn)
        {
            movePlayerScript.StartCompter = true;
        }
    }
}
