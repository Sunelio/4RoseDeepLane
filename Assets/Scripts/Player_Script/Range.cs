using UnityEngine;

public class Range : MonoBehaviour
{
    public MovePlayer player;
    void Update()
    {
        transform.position = player.transform.position;
    }
}
