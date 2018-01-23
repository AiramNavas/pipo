using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneButton : MonoBehaviour {

    private AudioSource aud;

    public AudioClip clip;

    private void Start()
    {
        aud = GetComponent<AudioSource>();
        aud.clip = clip;
    }

    private IEnumerator PlaySoundButton(int scene)
    {
        aud.Stop();
        aud.Play();
        yield return new WaitForSeconds(aud.clip.length);
        LoadingScreenManager.LoadScene(scene);
    }

    public void LoadSceneNum (int num) {
        StartCoroutine(PlaySoundButton(num));
    }
}
