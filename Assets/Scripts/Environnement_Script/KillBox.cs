using UnityEngine;

public class KillBox : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Box box = other.GetComponent<Box>();

        if (box)
        {
            Rigidbody rbBox = box.GetComponent<Rigidbody>();
            rbBox.velocity = new Vector3(0, 0, 0);
            box.transform.position = box.boxState.spawnPosition;
            box.boxState.gravityState = box.boxState.spawnGravity;
        }
    }
}