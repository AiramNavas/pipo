using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringSoft : MonoBehaviour
{
    public float minLight;
    public float maxLight;
    public float multiplier;
    private Light light;

    private void Start()
    {
        light = GetComponent<Light>();
    }

    private void Update()
    {
        light.intensity += Random.Range(-0.1f, +0.1f) * multiplier;
        if (light.intensity < minLight) light.intensity = minLight;
        if (light.intensity > maxLight) light.intensity = maxLight;
    }
}
