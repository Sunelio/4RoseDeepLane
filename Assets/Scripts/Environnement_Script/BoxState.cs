using UnityEngine;

public class BoxState : MonoBehaviour
{
    [Header("StateBox")]

    public bool inRange;
    [HideInInspector] public Vector3 spawnPosition;
    public bool isInRightRoom;

    [Header("StateGravity")]

    public bool canChangeGravity;
    public bool isInGravityZone;
    public Vector3 direction;
    public GravityState spawnGravity;
    public GravityState gravityState;
}
