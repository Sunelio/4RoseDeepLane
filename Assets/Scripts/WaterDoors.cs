using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDoors : MonoBehaviour
{
    public Water[] waterDetector;
    public Animator animator;
    public bool open;
    public bool close;
    // Update is called once per frame
    void Update()
    {
        bool allButtonOpen = true;
        foreach (Water P in waterDetector)
        {
            if (!P.open)
            {
                allButtonOpen = false;
            }
            else
            {
                allButtonOpen = true;
            }
        }
        if (allButtonOpen)
        {
            close = false;
            open = true;
        }
        else
        {
            close = true;
            open = false;
        }


        animator.SetBool("Close", close);
        animator.SetBool("Open", open);
    }
}

