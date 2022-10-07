using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateZibra : MonoBehaviour
{
    public GameObject[] objectsActivate;
    private void OnTriggerEnter(Collider other)
    {
        MovePlayer player = other.GetComponent<MovePlayer>();
        if (player)
        {

            foreach (GameObject P in objectsActivate)
            {
                P.SetActive(true);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        MovePlayer player = other.GetComponent<MovePlayer>();
        if (player)
        {

            foreach (GameObject P in objectsActivate)
            {
                P.SetActive(false);
            }
        }
    }
}
