using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.zibra.liquid.DataStructures;

public class WaterGravity : MonoBehaviour
{
    public LeverSwitch buton;
    public ZibraLiquidSolverParameters gravityWater;
    private Vector3 newGravity;
    private Vector3 initGravity;

    private void Start()
    {
        newGravity = new Vector3(0, -9.81f, 0);
        initGravity = gravityWater.Gravity;
    }
    void Update()
    {
        if (buton.open)
        {
            if (gravityWater.Gravity != newGravity)
            {
                gravityWater.Gravity = newGravity;
            }

        }
        else
        {
            if (gravityWater.Gravity != initGravity)
            {
                gravityWater.Gravity = initGravity;
            }
        }
    }
}