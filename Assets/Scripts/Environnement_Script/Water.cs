using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.zibra.liquid.Manipulators;

public class Water : MonoBehaviour
{
    public int water;
    public bool open;

    private void Update()
    {
        if (GetComponent<ZibraLiquidDetector>().particlesInside >= water)
        {
            open = true;
        }
        else
            open = false;
    }
        

}
