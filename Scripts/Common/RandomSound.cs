using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSound : MonoBehaviour {

    private float randomTime;
    private float elapsedTime;
    private bool done;

    private void Start()
    {
        done = false;
        elapsedTime = 0;
        randomTime = Random.Range(7f, 30f);
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > randomTime && !done)
        {
            GetComponent<AudioSource>().Play();
            done = true;
        }
    }
}
