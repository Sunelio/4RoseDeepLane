using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
public class SetActiveFlame : MonoBehaviour
{
    public VisualEffect[] fire;
    public DalleSwitchOff deathZone;
    public Light[] lightsFire;
    [SerializeField] private float initIntensity;

    private void Awake()
    {
        initIntensity = lightsFire[0].intensity;
    }

    private void Update()
    {
        if (!deathZone.isActivated)
        { 
            foreach (VisualEffect effect in fire)
            {
                effect.Play();
            }

            foreach (Light effect in lightsFire)
            {
                effect.intensity = Mathf.Clamp(effect.intensity, 0, initIntensity);
                effect.intensity += 100 * Time.deltaTime;
            }
        }

        else
        {
            foreach (VisualEffect effect in fire)
            {
                effect.Stop();
            }

            foreach (Light effect in lightsFire)
            {
                effect.intensity = Mathf.Clamp(effect.intensity, 0, initIntensity);
                effect.intensity -= 100 * Time.deltaTime;

            }
        }

    }
}
