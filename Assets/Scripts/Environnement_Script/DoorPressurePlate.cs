using UnityEngine;

public class DoorPressurePlate : MonoBehaviour
{
    public DalleSwitchOn[] pressurePlate;
    public Animator animator;
    public bool open;
    public bool close;
    //private AudioManager audioM;
    void Start()
    {
        //audioM = FindObjectOfType<AudioManager>();
    }
    void Update()
    {
        bool allButtonOpen = true;
        foreach (DalleSwitchOn P in pressurePlate)
        {
            if (!P.isActivated)
            {
                allButtonOpen = false;
            }
        }
        if (allButtonOpen)
        {
            close = false;
            open = true;
            //audioM.PlaySoundObject("DoorOpen");
            

        }
        else
        {
            close = true;
            open = false;
            //audioM.PlaySoundObject("DoorClose");
            
        }

        animator.SetBool("Close", close);
        animator.SetBool("Open", open);
    }
}