using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class LvlUP : MonoBehaviour
{
    public GameObject objectToDestroy;
    public bool isDestroy;
    private AudioManager audioM;
    private void Start()
    {
        audioM = FindObjectOfType<AudioManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        
        PlayerLevel playerLevel = other.GetComponent<PlayerLevel>();
        if (playerLevel != null)
        {
            audioM.PlaySoundObject("PowerUp");
            playerLevel.level += 1;
            isDestroy = true;
            Destroy(objectToDestroy);
            
        }
    }
   
}
