using UnityEngine;

public class zibraTrigger : MonoBehaviour
{
    public GameObject zibraContainer;
    public bool isActive = false;

    private void Awake()
    {
        zibraContainer.SetActive(isActive);
    }

    private void OnTriggerEnter(Collider other)
    {
        MovePlayer player = other.GetComponent<MovePlayer>();
        if (player)
        {
            zibraContainer.SetActive(!isActive);
        }
        
    }
}
