using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingManager : MonoBehaviour
{
    //References
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightingPreset Preset;
    //Variables
    public static float MaxTimeOfDay = 150f;
    [Range(0, 1000)] public float TimeOfDay = 0f;

    public delegate void OnNightHandler();
    public event OnNightHandler OnNight;
    public delegate void OnDayHandler();
    public event OnDayHandler OnDay;


    private void Update()
    {
        if(Preset == null)
        {
            return;
        }
        if(TimeOfDay < 0.75f * MaxTimeOfDay && TimeOfDay + Time.deltaTime > (MaxTimeOfDay * 0.75f))
        {
            OnNight.Invoke();
        }
        if (TimeOfDay < 0.25f * MaxTimeOfDay && TimeOfDay + Time.deltaTime > (MaxTimeOfDay * 0.25f))
        {
            OnDay.Invoke();
        }
        TimeOfDay += Time.deltaTime;
        TimeOfDay %= MaxTimeOfDay;
        UpdateLighting(TimeOfDay / MaxTimeOfDay);
    }
    private void UpdateLighting(float timePercent)
    {
        RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = Preset.FogColor.Evaluate(timePercent);
        if(DirectionalLight != null)
        {
            DirectionalLight.color = Preset.DirectionalColor.Evaluate(timePercent);
            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90, 170, 0));
        }
    }
    private void OnValidate()
    {
        if(DirectionalLight != null)
        {
            return;
        }
        if(RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun;
        }
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach(Light l in lights)
            {
                if(l.type == LightType.Directional)
                {
                    DirectionalLight = l;
                    return;
                }
            }
        }
    }
}
