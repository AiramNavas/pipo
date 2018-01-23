using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /**
     * Evento de colisión. En este caso, si se colisiona con el jugador, se llama al handler
     * y se destruye el punto.
     */
    private void OnCollisionEnter(Collision collision) {

        if (collision.gameObject.tag == "Player") {
            DelegateHandler.delegateHandler.CallOnCharacterGetsPoint();
            Destroy(gameObject);
        }
    }
}
