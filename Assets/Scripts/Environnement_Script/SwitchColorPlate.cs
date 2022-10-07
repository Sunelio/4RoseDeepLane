using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchColorPlate : MonoBehaviour
{
    [SerializeField] private DalleSwitchOn[] buttons;
    [SerializeField] private Light backgroundLight;
    [SerializeField] private Light areaLight;
    [SerializeField] private Color[] colors;
    [SerializeField] private Color areaColor;
    private int counter;

    void Update()
    {
        counter = 0;
        foreach (DalleSwitchOn L in buttons)
        {
            if (L.isActivated)
            {
                counter++;
            }
        }
        backgroundLight.color = colors[counter];

        if(counter == colors.Length - 1)
        {
            areaLight.color = areaColor;
        }
    }
}
