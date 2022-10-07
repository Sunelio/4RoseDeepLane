using UnityEngine;
using System.Collections.Generic;

public class DalleSwitchOn : MonoBehaviour
{
    private GameObject ObjectTrigger;
    public bool isActivated = false;
    [HideInInspector]
    public List<Collider> ObjectsOnTrigger;
    private Animator animator;
    private AudioManager audioM;
    private void Start()
    {
        animator = GetComponent<Animator>();
        audioM = FindObjectOfType<AudioManager>();
    }
    public void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb)
        {
            if (!ObjectsOnTrigger.Contains(other))
            {
                ObjectsOnTrigger.Add(other);
                if (ObjectsOnTrigger.Count == 1)
                {
                    //ObjectTrigger.gameObject.SetActive(true);
                    isActivated = true;
                    animator.SetBool("Active", true);
                   audioM.PlaySoundObject("Pressure Plate Stone");
                }
            }
        }
            
    }
    public void OnTriggerExit(Collider other)
    {
        if (ObjectsOnTrigger.Contains(other))
        {
            ObjectsOnTrigger.Remove(other);
            if (ObjectsOnTrigger.Count == 0)
            {
                //ObjectTrigger.gameObject.SetActive(false);
                isActivated = false;
                animator.SetBool("Active", false);
                audioM.PlaySoundObject("Pressure Plate Stone");
            }

        }
    }
}
