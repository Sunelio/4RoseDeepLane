using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [Header("Camera position & Smoothness")]
    [Tooltip("Camera Y positon value in P1")]
    public float offsetInPosYInP1;
    [Tooltip("Camera Y positon value in P3")]
    public float offsetInPosYInP3;
    [Tooltip("Camera smoothness value in deplacement")]
    public float smoothnessPlayer;
    public float smoothnessFixCamera;
    [Tooltip("Camera smoothness rotation value when player change gravity")]
    public float smoothnessCameraOnMovement;
    [Tooltip("Camera smoothness rotation value when camera positon in Y change")]
    public float smoothnessCameraInStop;
    [Tooltip("Camera Z positon value")]
    public float cameraZPosition;
    [Tooltip("Camera Z positon 1 smallest Value")]
    public float positionForZcamera1;
    [Tooltip("Camera Z positon 2 highest Value")]
    public float positionForZcamera2;
    [Tooltip("Camera Z positon when we can change z position")]
    public float cameraAfterZChange;
    [HideInInspector] public Vector3 offset;

    [Header("Camera Box")]
    [Tooltip("The distance from the camera")]
    public Vector3 box1;
    public Vector3 box2;

    [Header("Reference")]
    [Tooltip("Script ref to Player")]
    public Transform player;
    [Tooltip("Script ref to PlayerState")]
    public PlayerState state;

    [Header("Other")]
    [Tooltip("Change camera rotation value")]
    public int rotationCameraValue;
    [HideInInspector] public Vector3 targetPosition;
    [HideInInspector] public Quaternion targetRotation;



    private void Start()
    {
        transform.position = GameObject.Find("Player").transform.position + offset;
        GameObject g = GameObject.Find("Player");
        state = g.GetComponent<PlayerState>();
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if (state.isCameraFollow)
        {
            targetPosition = player.position;
            targetPosition.x = Mathf.Clamp(targetPosition.x, box1.x, box2.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, box1.y, box2.y);
            targetPosition.z = cameraZPosition;
        }

        Vector3 newPos = Vector3.Lerp(transform.position - offset, targetPosition, smoothnessPlayer);
        transform.position = newPos + offset;

        if (state.curGravityState == GravityState.DOWN)
        {
            targetRotation = Quaternion.Euler(rotationCameraValue, 0, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, smoothnessCameraOnMovement);
            Vector3 newOffset = new Vector3(0, offsetInPosYInP1, 0);
            offset = Vector3.Lerp(offset, newOffset, smoothnessCameraInStop);
        }

        if (state.curGravityState == GravityState.UP || state.isPlayerTriggerCameraWall == true)
        {
            targetRotation = Quaternion.Euler(-rotationCameraValue, 0, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, smoothnessCameraOnMovement);
            Vector3 newOffset = new Vector3(0, offsetInPosYInP3, 0);
            offset = Vector3.Lerp(offset, newOffset, smoothnessCameraInStop);

        }

        if (state.curGravityState == GravityState.LEFT && state.isPlayerTriggerCameraWall == false || state.curGravityState == GravityState.RIGHT && state.isPlayerTriggerCameraWall == false)
        {
            targetRotation = Quaternion.Euler(rotationCameraValue, 0, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, smoothnessCameraOnMovement);
            Vector3 newOffset = new Vector3(0, offsetInPosYInP1, 0);
            offset = Vector3.Lerp(offset, newOffset, smoothnessCameraInStop);
        }

        if(state.isPlayerTriggerCameraZ == true)
        {
            cameraZPosition = Mathf.Clamp(player.position.z, positionForZcamera1, positionForZcamera2);
            cameraZPosition -= cameraAfterZChange;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(box1, box2);
    }
}
