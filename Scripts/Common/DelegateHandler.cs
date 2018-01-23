using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Clase que se encarga de los eventos del juego.
 */
public class DelegateHandler : MonoBehaviour {

    public static DelegateHandler delegateHandler; // Handler de eventos.

    public delegate void OnCharacterStepsOnTile(); // Delegado para cuando el personaje pisa una trampa.
    public event OnCharacterStepsOnTile onCharacterStepsOnTile; // Funciones suscritas al evento de trampa.

    public delegate void OnCharacterReceivesDamage(int damage); // El jugador recibe daño.
    public event OnCharacterReceivesDamage onCharacterReceivesDamage; // Funciones suscritas al evento de daño.

    public delegate void OnCharacterHeals(int cure); // El jugador se cura.
    public event OnCharacterHeals onCharacterHeals; // Funciones suscritas al evento de cura.

    public delegate void OnCharacterGetsPoint(); // El jugador consigue un punto.
    public event OnCharacterGetsPoint onCharacterGetsPoint; // Funciones suscritas al evento de punto.

    private const int SPIKES_DAMAGE = 20; // Daño por pinchos.
    private const int CONTAINER_CURE = 30; // Cura.
    private const int MAX_POINTS = 5; // Número máximo de puntos que pueden aparecer a la vez.
    private const int MAX_LIVES = 5; // Número máximo de curas que pueden aparecer a la vez.

    public GameObject point; // Gameobject que representa un punto.
    public int actualPoints = 0; // Número de puntos en escena actualmente.
    public Transform[] spawnPoints; // Array de posiciones donde pueden aparecer los puntos.

    public GameObject lifeContainer; // Gameobject que representa una vida.
    public int actualLives = 0; // Número de vidas en escena actualmente.
    public Transform[] spawnLives; // Array de posiciones donde pueden aparecer las vidas.


    public AudioClip healSound; // Audio reservado para el sonido al coger una cura
    public AudioClip trampSound; // Audio reservado para el sonido al coger un punto

    //public delegate void OnCharacterBends();
    //public event OnCharacterBends onCharacterBends;

    //public delegate void OnCharacterGetsUp();
    //public event OnCharacterGetsUp onCharacterGetsUp;

    /*
     * Inicializa el handler
     */
    public void Awake() {

        if (delegateHandler == null) {

            delegateHandler = this;
            DontDestroyOnLoad(this);

        } else if (delegateHandler != this) {

            Destroy(gameObject);
        }
    }

    // Actualización por frame. Se encarga de llamar a la función que hace aparecer los puntos y las vidas.
    void Update () {
        MakePointsSpawn();
        MakeLivesSpawn();
    }

    /*
     * Llama a las funciones suscritas al evento de pisar una trampa
     * y al de recibir daño.
     */
    public void CallOnCharacterStepsOnTile() {
        GetComponent<AudioSource>().clip = trampSound;
        GetComponent<AudioSource>().Play();
        onCharacterStepsOnTile();
        onCharacterReceivesDamage(SPIKES_DAMAGE);
    }

    /*
     * LLama a la funciones suscritas al evento de curar.
     */
    public void CallOnCharacterHeals() {
        GetComponent<AudioSource>().clip = healSound;
        GetComponent<AudioSource>().Play();
        onCharacterHeals(CONTAINER_CURE);
        actualLives--;
    }

    /**
     * Llama a las funciones suscritas al evento de punto.
     */
    public void CallOnCharacterGetsPoint() {
        GetComponent<AudioSource>().clip = healSound;
        GetComponent<AudioSource>().Play();
        onCharacterGetsPoint();
        actualPoints--;
    }

    /**
     * Se encarga de hacer aparecer los puntos en las posibles posiciones.
     */
    public void MakePointsSpawn () {
        if (actualPoints < MAX_POINTS) {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(point, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            actualPoints++;
        }
    }
    /**
     * Se encarga de hacer aparecer las vidas en las posibles posiciones.
     */
    public void MakeLivesSpawn () {
        if (actualLives < MAX_LIVES) {
            int spawnLifeIndex = Random.Range(0, spawnLives.Length);
            Instantiate(lifeContainer, spawnLives[spawnLifeIndex].position, spawnLives[spawnLifeIndex].rotation);
            actualLives++;
        }
    }

    /**
     * Función a la que se llama cuando muere el jugador.
     */
    public void CallCharacterIsDead () {
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }

    /*
    public void CallOnCharacterBends()
    {
        onCharacterBends();
    }

    public void CallOnCharacterGetsUp()
    {
        onCharacterGetsUp();
    }*/
}
