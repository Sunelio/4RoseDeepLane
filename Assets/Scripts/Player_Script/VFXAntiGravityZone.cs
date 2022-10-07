using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class VFXAntiGravityZone : MonoBehaviour
{
    public Volume volume;
    private float speed = 80;
    public float speedIntensityVignette = 0.01f;
    public float speedIntensityFilmGrain = 0.01f;
    public bool isVignetteFade;

    public void Update()
    {
        if (isVignetteFade)
        {
            IncreaseValueVignette();
            IncreaseValueFilmGrain();
            IncreaseValueWhiteBalance();
        }
        if(!isVignetteFade)
        {
            DecreaseValueVignette();
            DecreaseValueFilmGrain();
            DecreaseValueWhiteBalance();
        }
    }
    public void IncreaseValueVignette()
    {
        if (volume.profile.TryGet<Vignette>(out var vignette))
        {
            if (vignette.intensity.value != speedIntensityVignette)
            {
                vignette.intensity.value = Mathf.Clamp(vignette.intensity.value, 0f, 0.355f);
                vignette.smoothness.value = Mathf.Clamp(vignette.smoothness.value, 0f, 0.4f);
                vignette.roundness.value = Mathf.Clamp(vignette.roundness.value, 0f, 0.25f);
            }
            vignette.intensity.value += speedIntensityVignette * Time.deltaTime * speed;
            vignette.smoothness.value += speedIntensityVignette * Time.deltaTime * speed;
            vignette.roundness.value += speedIntensityVignette * Time.deltaTime * speed;


        }
    }
    public void DecreaseValueVignette()
    {
        if (volume.profile.TryGet<Vignette>(out var vignette))
        {
            vignette.intensity.value -= speedIntensityVignette * Time.deltaTime * speed;
            vignette.smoothness.value -= speedIntensityVignette * Time.deltaTime * speed;
            vignette.roundness.value -= speedIntensityVignette * Time.deltaTime * speed;
            vignette.intensity.value = Mathf.Clamp(vignette.intensity.value, 0f, 0.355f);
            vignette.smoothness.value = Mathf.Clamp(vignette.smoothness.value, 0f, 0.4f);
            vignette.roundness.value = Mathf.Clamp(vignette.roundness.value, 0f, 0.25f);
        }


    }
    public void IncreaseValueFilmGrain()
    {
        if (volume.profile.TryGet<FilmGrain>(out var filmGrain))
        {
            filmGrain.intensity.value += speedIntensityFilmGrain * Time.deltaTime * speed;
            filmGrain.response.value += speedIntensityFilmGrain * Time.deltaTime * speed;
            filmGrain.intensity.value = Mathf.Clamp(filmGrain.intensity.value, 0f, 0.55f);
            filmGrain.response.value = Mathf.Clamp(filmGrain.response.value, 0f, 0.585f);
        }
    }
    public void DecreaseValueFilmGrain()
    {
        if (volume.profile.TryGet<FilmGrain>(out var filmGrain))
        {
            filmGrain.intensity.value -= speedIntensityFilmGrain * Time.deltaTime * speed;
            filmGrain.response.value -= speedIntensityFilmGrain * Time.deltaTime * speed;
            filmGrain.intensity.value = Mathf.Clamp(filmGrain.intensity.value, 0f, 0.55f);
            filmGrain.response.value = Mathf.Clamp(filmGrain.response.value, 0f, 0.585f);
        }


    }
    public void IncreaseValueWhiteBalance()
    {
        if (volume.profile.TryGet<WhiteBalance>(out var whiteBalance))
        {
            whiteBalance.temperature.value += 1f * Time.deltaTime * speed;
            whiteBalance.tint.value += 1f * Time.deltaTime * speed;
            whiteBalance.temperature.value = Mathf.Clamp(whiteBalance.temperature.value, 0f, 93f);
            whiteBalance.tint.value = Mathf.Clamp(whiteBalance.tint.value, 0f, 57f);
        }
    }
    public void DecreaseValueWhiteBalance()
    {
        if (volume.profile.TryGet<WhiteBalance>(out var whiteBalance))
        {
            whiteBalance.temperature.value -= 1f * Time.deltaTime * speed;
            whiteBalance.tint.value -= 1f * Time.deltaTime * speed;
            whiteBalance.temperature.value = Mathf.Clamp(whiteBalance.temperature.value, 0f, 93f);
            whiteBalance.tint.value = Mathf.Clamp(whiteBalance.tint.value, 0f, 57f);
        }


    }
}
