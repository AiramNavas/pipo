using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActionButton : MonoBehaviour {

    private AudioSource aud;

    public AudioClip clickButton;

    // Use this for initialization
    void Start () {
        aud = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private IEnumerator PlaySoundButton(string scene) {
        aud.Stop();
        aud.clip = clickButton;
        aud.Play();
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    public void LoadMenu()
    {
        StartCoroutine(PlaySoundButton("MainMenu"));
    }

    public void Exit()
    {
        Application.Quit();
    }
    
}
