using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class CameraPlacement : MonoBehaviour
{

    [Header("Camera Box")]
    [Tooltip("The distance from the camera ")]
    [SerializeField]
    private Vector3 box1;
    [SerializeField] 
    private Vector3 box2;

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Camera.main.GetComponent<CameraBehaviour>().box1 = box1;
            Camera.main.GetComponent<CameraBehaviour>().box2 = box2;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(box1, box2);
        Gizmos.DrawLine(box1, new Vector3(box2.x, box1.y));
        Gizmos.DrawLine(box2, new Vector3(box1.x, box2.y));
        Gizmos.DrawLine(box1, new Vector3(box1.x, box2.y));
        Gizmos.DrawLine(box2, new Vector3(box2.x, box1.y));
        Gizmos.DrawWireSphere(box1, 1);
        Gizmos.DrawWireSphere(box2, 1);
    }
}
