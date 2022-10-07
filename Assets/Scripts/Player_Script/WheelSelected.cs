 using UnityEngine;
using UnityEngine.VFX;

public class WheelSelected : MonoBehaviour
{
    [Header("lvl")]
    public  PlayerLevel levelPlayer;

    [Header("VFX")]
    [Tooltip("List of all the VFX we have to modif")]
    public VisualEffect[] vfx;
    [SerializeField] private Gradient initVfxColor;
    [Tooltip("The color of the VFX when he is Selected")]
                     public Gradient vfxColor;
    [SerializeField] private float initVfxLifeTime;
    [Tooltip("The life time of the VFX when he is Selected")]
                     public float vfxLifeTime;

    [Header("other")]
    [Tooltip("ref to the position Game Object Player")]
    public GameObject player;
    [Tooltip("ref to the Player State script")]
    public PlayerState state;

    public void Awake()
    {
        initVfxLifeTime = vfx[0].GetFloat("Lifetime");
        initVfxColor = vfx[0].GetGradient("Color");
 

    }
    private void Update()
    {
        transform.position = player.transform.position;
    }
    public void SetVfxValue()
    {
        switch (state.gravity)
        {
            case GravityState.UP:
                    vfx[3].SetGradient("Color", vfxColor);

                    vfx[2].SetGradient("Color", initVfxColor);
                    vfx[1].SetGradient("Color", initVfxColor);
                    vfx[0].SetGradient("Color", initVfxColor);

                    vfx[3].SetFloat("Lifetime", vfxLifeTime);

                    vfx[2].SetFloat("Lifetime", initVfxLifeTime);
                    vfx[1].SetFloat("Lifetime", initVfxLifeTime);
                    vfx[0].SetFloat("Lifetime", initVfxLifeTime);
                break;
            case GravityState.DOWN:
                vfx[2].SetGradient("Color", vfxColor);

                vfx[0].SetGradient("Color", initVfxColor);
                vfx[1].SetGradient("Color", initVfxColor);
                vfx[3].SetGradient("Color", initVfxColor);

                vfx[2].SetFloat("Lifetime", vfxLifeTime);
                vfx[3].SetFloat("Lifetime", initVfxLifeTime);
                vfx[1].SetFloat("Lifetime", initVfxLifeTime);
                vfx[0].SetFloat("Lifetime", initVfxLifeTime);
                break;
            case GravityState.LEFT:
                vfx[1].SetGradient("Color", vfxColor);

                vfx[2].SetGradient("Color", initVfxColor);
                vfx[3].SetGradient("Color", initVfxColor);
                vfx[0].SetGradient("Color", initVfxColor);

                vfx[1].SetFloat("Lifetime", vfxLifeTime);

                vfx[2].SetFloat("Lifetime", initVfxLifeTime);
                vfx[3].SetFloat("Lifetime", initVfxLifeTime);
                vfx[0].SetFloat("Lifetime", initVfxLifeTime);
                break;
            case GravityState.RIGHT:
                vfx[0].SetGradient("Color", vfxColor);

                vfx[1].SetGradient("Color", initVfxColor);
                vfx[2].SetGradient("Color", initVfxColor);
                vfx[3].SetGradient("Color", initVfxColor);

                vfx[0].SetFloat("Lifetime", vfxLifeTime);

                vfx[1].SetFloat("Lifetime", initVfxLifeTime);
                vfx[2].SetFloat("Lifetime", initVfxLifeTime);
                vfx[3].SetFloat("Lifetime", initVfxLifeTime);
                break;
        }

    }
}
