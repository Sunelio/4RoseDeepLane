using UnityEngine;

public class DropBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        MovePlayer player = other.GetComponent<MovePlayer>();
        if (player)
        {
            if (player.state.isGrabing)
            {
                Grab playerGrab = other.GetComponent<Grab>();
                Rigidbody objRig = playerGrab.heldObj.GetComponent<Rigidbody>();
                player.state.isGrabing = false;
                objRig.transform.parent = null;
                objRig.freezeRotation = false;
                objRig.isKinematic = false;
                playerGrab.heldObj = null;
            }
        }
        
    }

}
