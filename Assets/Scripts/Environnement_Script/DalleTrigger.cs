using UnityEngine;
using System.Collections.Generic;

public class DalleTrigger : MonoBehaviour
{
    public GameObject door;
    public bool isActivated = false;
    public List<Collider> ObjectsOnTrigger;
    public void OnTriggerEnter(Collider other)
    {
        if (!ObjectsOnTrigger.Contains(other))
        {
            ObjectsOnTrigger.Add(other);
            if (ObjectsOnTrigger.Count == 1)
            {
                door.transform.position += new Vector3(0, 4, 0);
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
                door.transform.position += new Vector3(0, -4, 0);
            }

        }
    }
}
