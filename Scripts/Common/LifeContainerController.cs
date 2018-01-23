using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Clase que se encarga de controlar los eventos relacionados con los 
 * contenedores de vida. 
 */
public class LifeContainerController : MonoBehaviour {

	// Inicialización.
	void Start () {}
	
	// Actualización por frame.
	void Update () {}
    
    /**
     * Evento de colisión. En este caso, si se colisiona con el jugador, se llama al handler
     * y se destruye el contenedor.
     */
    private void OnCollisionEnter(Collision collision) {

        if (collision.gameObject.tag == "Player") {
            DelegateHandler.delegateHandler.CallOnCharacterHeals();
            Destroy(gameObject);
        }
    }
}
