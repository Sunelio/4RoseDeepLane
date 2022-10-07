using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTimer : MonoBehaviour
{
    [SerializeField] public float deathTime = 4f;

    void Update()
    {
        if(deathTime <= 0f)
        {
            Debug.Log("Game Over");
        }
        else
        {
            deathTime -= Time.deltaTime;
            Debug.Log(deathTime);
        }
        
    }
}
