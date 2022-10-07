using UnityEngine;
public class Grab : MonoBehaviour
{

    [Header("Other")]
    public float initSpeed;
    public float initRun;
    private float initJump;
    public bool isInit;
    private Vector3 initDestPos;
    private Vector3 colPos;
    private Quaternion colRotation;
    public GameObject colliderToLoad;
    [Tooltip("This is the object which is grabbing")]
    public Transform holdParent;
    [Tooltip("This is where the object grabbed go")]
    public Transform theDest;
    public Transform theDestLight;
    [Tooltip("This is the deplacement of the player")]
    public MovePlayer player;
    [HideInInspector] public GameObject heldObj;
    private AudioManager audioM;

    private void Start()
    {
        initDestPos = theDest.transform.localPosition;
        initRun = player.running;
        initJump = player.jumpForce;
        initSpeed = player.moveSpeed;
        audioM = FindObjectOfType<AudioManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Box test = other.GetComponent<Box>();
        if (test != null)
        {
            colRotation = other.transform.localRotation;
            colPos = other.transform.localPosition;
            Debug.Log("have it");
            player.state.canGrab = true;
           
        }
    }
    private void OnTriggerStay(Collider other)
    {
        Box test = other.GetComponent<Box>();
        if (test != null)
        {
            if (player.state.canGrab && player.state.isGrabing)
            {
                WeightState(other.gameObject);
                PickUpObject(other.gameObject);
                ChangeSpeed();
                test.boxState.gravityState = player.state.curGravityState;

            }

                if (player.state.cancelGrab || !player.state.canGrab)
                {

                    DropBox(other.gameObject);
                    player.state.weight = BoxWeight.NONE;
                }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Box test = other.GetComponent<Box>();
        if (test)
        {
            player.state.canGrab = false;
        }
            

    }
    public void ChangeSpeed()
    {
        switch (player.state.weight)
        {
            case BoxWeight.NONE:
                player.moveSpeed = Mathf.Clamp(player.moveSpeed, 0, initSpeed);
                break;
            case BoxWeight.MEDIUM:
                player.moveSpeed = Mathf.Clamp(player.moveSpeed, 0, 250);
                player.running = 400;
                break;
            case BoxWeight.HEAVY:
                player.moveSpeed = Mathf.Clamp(player.moveSpeed,0,150);
                player.running = 200;
                player.jumpForce = 0;
                break;
            default:
                break;
        }
    }
    public void PickUpObject(GameObject pickObject)
    {

        isInit = true;
        Collider objCol = pickObject.GetComponent<Collider>();
        Rigidbody objRig = pickObject.GetComponent<Rigidbody>();
        BoxCollider collider = colliderToLoad.GetComponent<BoxCollider>();
        objRig.transform.parent = holdParent;
        objRig.freezeRotation = true;
        objRig.isKinematic = true;
        pickObject.layer = 8;
            
        initColider(collider, objCol);
            
        if (pickObject.tag == "Medium_Box")
        {
            if (pickObject.transform.position != theDest.position)
            {
                pickObject.transform.position = theDest.position;
            }
        }
        if(pickObject.tag == "Light_Box")
        {
            pickObject.transform.position = theDestLight.position;
        }

            heldObj = pickObject;

    }

    public void DropBox(GameObject heldObj)
    {

           
            BoxCollider collider = colliderToLoad.GetComponent<BoxCollider>();
            DisableColider(collider);
            heldObj.layer = 3;
            player.running = initRun;
            isInit = false;
             player.jumpForce = initJump;
            Rigidbody objRig = heldObj.GetComponent<Rigidbody>();
            objRig.transform.parent = null;
             objRig.freezeRotation = false;
             objRig.isKinematic = false;
            heldObj = null;

    }

    private void initColider(BoxCollider collider, Collider objCol)
    {
        colliderToLoad.SetActive(true);
        colliderToLoad.transform.localRotation = colRotation;
        collider.size = objCol.bounds.size;
        colliderToLoad.transform.localPosition = colPos;


    }
    private void DisableColider(BoxCollider collider)
    {
        colliderToLoad.SetActive(false);
        collider.size = Vector3.one;
        colliderToLoad.transform.localRotation = transform.localRotation;
        colliderToLoad.transform.localPosition = Vector3.zero;
    }


    private void WeightState(GameObject pickObj)
    {
        if (pickObj.transform.tag == "Heavy_Box")
        {
            player.state.weight = BoxWeight.HEAVY;
        }
        if (pickObj.transform.tag == "Medium_Box")
        {
            player.state.weight = BoxWeight.MEDIUM;
        }
        if (pickObj.transform.tag == "Light_Box")
        {
            player.state.weight = BoxWeight.LIGHT;
        }
    }
}
