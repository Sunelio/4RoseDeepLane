using System.Collections;
using System.Collections.Generic;
using UnityEngine.Animations;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    public Button[] buttons;
    public Animator animator;
    public bool open;
    public bool close;

    // Update is called once per frame
    void Update()
    {
        bool allButtonOpen = true;
        foreach(Button B in buttons )
        {
            if(!B.buttonActive)
            {
                allButtonOpen = false;
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
