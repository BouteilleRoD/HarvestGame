using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingManager : MonoBehaviour
{
    //References
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightingPreset Preset;
    //Variables
    [Range(0,150)] public float TimeOfDay = 76f;



    private void Update()
    {
        if(Preset == null)
        {
            return;
        }
        TimeOfDay += Time.deltaTime;
        TimeOfDay %= 150;
        UpdateLighting(TimeOfDay / 150f);
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
