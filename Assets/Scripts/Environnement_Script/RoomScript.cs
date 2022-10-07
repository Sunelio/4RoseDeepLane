using UnityEngine;

public class RoomScript : MonoBehaviour
{
    private Collider[] collidersInRoom;
    public Collider[] boxesInRoom;
    public bool isPlayerInRoom;
    private Collider collisionBox;
    void Start()
    {
        collisionBox = GetComponent<BoxCollider>();
        collidersInRoom = Physics.OverlapBox(transform.position, collisionBox.transform.localScale / 2);

        //Debug.Log("Colliders in room ");
        foreach (Collider box in collidersInRoom)
        {
            isPlayerInRoom = false;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        PlayerLevel player = other.GetComponent<PlayerLevel>();
        if (player)
        {
            isPlayerInRoom = true;
            foreach (Collider box in boxesInRoom)
            {
                box.GetComponent<BoxState>().isInRightRoom = isPlayerInRoom;
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        PlayerLevel player = other.GetComponent<PlayerLevel>();
        if (player)
        {
            isPlayerInRoom = false;
            foreach (Collider box in boxesInRoom)
            {
                box.GetComponent<BoxState>().isInRightRoom = isPlayerInRoom;
            }
        }
    }
}