using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPPlayerLeverCellar : MonoBehaviour
{
    // Inspector
    [SerializeField] private LeverSwitch lever;
    [SerializeField] private GameObject spawnPos;

    // Private
    private GameObject player;
    private bool hasBeenUsed = false;

    private void Awake()
    {
        player = FindObjectOfType<MovePlayer>().gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        if (lever.open && !hasBeenUsed) // TP Player
        {
            player.transform.position = spawnPos.transform.position;
            hasBeenUsed = true;
        }
    }
}
