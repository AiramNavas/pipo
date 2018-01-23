using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Clase que se encarga de controlar los eventos relacionados con el jugador.
 */
public class CharacterOwnController : MonoBehaviour {

    public int life = 100; // Vida del jugador.
    public int points = 0; // Puntos del jugador.

    public const int MAX_HP = 100; // Máxima vida del jugador. 

    public Text scoreText;
    public Text hpText;

    /*
     * Inicialización
     */
    void Start() {
        DelegateHandler.delegateHandler.onCharacterReceivesDamage += receiveDamage;
        DelegateHandler.delegateHandler.onCharacterHeals += healDamage;
        DelegateHandler.delegateHandler.onCharacterGetsPoint += addPoint;
    }

    /**
     * Función que se encarga de quitarle vida al personaje.
     */
    void receiveDamage (int damage) {
        if (damage < life)
            life -= damage;
        else {
            life = 0;
            DelegateHandler.delegateHandler.CallCharacterIsDead();
        }
        
    }

    /**
     * Función que se encarga de darle vida al personaje
     */
    void healDamage (int cure) {
        if (life + cure > MAX_HP)
            life = MAX_HP;
        else
            life += cure; 
    }

    /**
     * Añade un punto a la puntuación del jugador.
     */
    void addPoint () {
        points++;
    }

    /**
     * Se encarga de eliminarse de la lista de eventos.
     */
    void OnDisable() {
        DelegateHandler.delegateHandler.onCharacterReceivesDamage -= receiveDamage;
        DelegateHandler.delegateHandler.onCharacterHeals -= healDamage;
        DelegateHandler.delegateHandler.onCharacterGetsPoint -= addPoint;
    }

    /*
     * Actualización pro frame. Se encarga de que la luz de la linterna siga a la cámara.
     */
    void Update () {
        if (transform.childCount > 1)
        {
            float eyes_direction = transform.GetChild(0).localEulerAngles.x;
            transform.GetChild(1).transform.localEulerAngles = new Vector3(eyes_direction, 0, 0);
            transform.GetChild(2).transform.localEulerAngles = new Vector3(eyes_direction, 0, 0);
        }

        scoreText.text = "PTS: " + points.ToString();
        hpText.text = "HP: " + life.ToString();
    }
}
