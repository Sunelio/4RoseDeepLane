using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activeLevelPart : MonoBehaviour
{
    public GameObject levelPart;
    private bool isLevelPartActive = false;

    // Start is called before the first frame update
    void Start()
    {
        levelPart.SetActive(isLevelPartActive);
    }

    private void OnTriggerEnter(Collider other)
    {
        MovePlayer player = other.GetComponent<MovePlayer>();
        if (player)
        {
            levelPart.SetActive(!isLevelPartActive);
            gameObject.SetActive(false);
        }
    }
}