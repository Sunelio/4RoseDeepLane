using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPowerUp : MonoBehaviour
{
    public GameObject textTutoGravityChange;
    //public GameObject playerRef;

    // Start is called before the first frame update
    void Start()
    {
        textTutoGravityChange.SetActive(false);
    }

    private void OnTriggerEnter(Collider Player)
    {
        textTutoGravityChange.SetActive(true);
    }
}
