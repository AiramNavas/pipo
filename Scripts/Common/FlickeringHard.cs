using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringHard : MonoBehaviour
{
    public float threshold;
    private Light light;

	private void Start ()
    {
        light = GetComponent<Light>();
    }
	
	private void Update ()
    {
        if (Random.Range(0f, 1f) > threshold)
            light.enabled = !light.enabled;
	}
}
