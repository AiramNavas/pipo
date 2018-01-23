using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepetitiveSound : MonoBehaviour {

    private float elapsed;

    private void Start()
    {
        elapsed = 0;
    }

    private void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed > 15)
        {
            elapsed -= 15;
            GetComponent<AudioSource>().Play();
        }
    }
}
