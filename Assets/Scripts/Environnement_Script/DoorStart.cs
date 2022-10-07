using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorStart : MonoBehaviour
{
    // Start is called before the first frame update
    public StartLvl buttons;
    public GameObject[] lightToSet;
    public bool open;
    public bool close;

    // Update is called once per frame
    void Update()
    {
        if (buttons.open)
        {
            open = true;
            close = false;
            foreach(GameObject l in lightToSet)
            {
                l.SetActive(false);
            }
        }
        else
        {
            close = true;
            open = false;
            foreach (GameObject l in lightToSet)
            {
                l.SetActive(true);
            }
        }
        
    }
}
