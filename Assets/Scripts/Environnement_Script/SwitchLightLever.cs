using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLightLever : MonoBehaviour
{
    public LeverSwitch[] buttons;
    public GameObject[] lightToSet;
    public bool invers;

    void Update()
    {
        bool allButtonOpen = true;
        foreach (LeverSwitch L in buttons)
        {
            if (!L.open)
            {
                allButtonOpen = false;
            }
        }
        if (allButtonOpen)
        {
            if (invers)
            {
                foreach (GameObject g in lightToSet)
                {
                    g.SetActive(true);
                }
            }
            else
            {
                foreach (GameObject g in lightToSet)
                {
                    g.SetActive(false);
                }
            }
        }
        else
        {
            if (invers)
            {
                foreach (GameObject g in lightToSet)
                {
                    g.SetActive(false);
                }
            }
            else
            {
                foreach (GameObject g in lightToSet)
                {
                    g.SetActive(true);
                }
            }
        }
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("is here");
        MovePlayer test = other.GetComponent<MovePlayer>();
        if (test != null)
        {
            test.StartCompter = false;
            test.deathCompter = test.initDeathCompter;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        MovePlayer test = other.GetComponent<MovePlayer>();
        if (test != null)
        {
            test.StartCompter = true;
        }
    }
    */
}
