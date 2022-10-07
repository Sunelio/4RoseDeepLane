using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLever : MonoBehaviour
{
    // Start is called before the first frame update
    public LeverSwitch[] buttons;
    public Animator animator;
    public bool open;
    public bool close;

    // Update is called once per frame
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
            open = true;
            close = false;
        }
        else
        {
            open = false;
            close = true;
        }
    
        animator.SetBool("Close", close);
        animator.SetBool("Open", open);
    }
}
