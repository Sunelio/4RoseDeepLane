using UnityEngine;
using System.Collections.Generic;

public class DalleSwitchOff : MonoBehaviour
{
    public GameObject[] ObjectTrigger;
    public bool isActivated = false;
    public List<Collider> ObjectsOnTrigger;
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
                    foreach (GameObject obj in ObjectTrigger)
                    {
                        obj.SetActive(false);
                        isActivated = true;
                    }
                    
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
                foreach (GameObject obj in ObjectTrigger)
                {
                    obj.SetActive(true);
                    isActivated = false;
                }
            }

        }
    }
}
