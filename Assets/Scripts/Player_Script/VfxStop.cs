using System.Collections;
using System.Collections.Generic;
using UnityEngine.VFX;
using UnityEngine;

public class VfxStop : MonoBehaviour
{
    private VisualEffect lvlUP;
    public LvlUP isDestroy;
    private bool active; 
    public int destroyTime = 3;

    private void Awake()
    {
        lvlUP = GetComponent<VisualEffect>();
    }
    void Update()
    {
        if(isDestroy.isDestroy && !active)
        {
            lvlUP.Stop();
            active = true;
            StartCoroutine(destroyVfx());
        }
            
    }

    private IEnumerator destroyVfx()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(lvlUP);
    }
}
