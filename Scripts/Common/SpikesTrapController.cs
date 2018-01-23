using UnityEngine;
using System.Collections;
/**
 * Clase que se encarga de controlar los eventos relacionados con las
 * trampas de pinchos.
 */
public class SpikesTrapController : MonoBehaviour
{
    private const float SPIKES_OUT_TIME = 5.0f; // Tiempo que tardan los pinchos en retraerse.
    public bool enabled; // Trampa activada o no.
    public float targetTime = SPIKES_OUT_TIME; // Tiempo desde que se activó la trampa.
    public bool collisioned = false; // Si el jugador ha pisado la trampa o no.
    public bool spikesOut = false; // Si los pinchos están fuera.

    // Inicialización.
    void Start()
    {
        DelegateHandler.delegateHandler.onCharacterStepsOnTile += moveSpikes;
    }

    /*
     * Actualización por frame. En este caso, si se ha pisado la trampa, va descontando el tiempo
     * que queda hasta que los pinchos deban retraerse.
     */
    void Update()
    {
        if (spikesOut)
        {
            targetTime -= Time.deltaTime;

            if (targetTime <= 0.0f)
                timerEnded();
        }
    }

    /**
     * Se llama cuando se termina el contador para que los pinchos se retraigan.
     * Pone la variable que indica si se ha pisado la trampa a false, reinicia el temporizador
     * y retrae los pinchos.
     */
    void timerEnded()
    {
        spikesOut = false;
        targetTime = SPIKES_OUT_TIME;
        retractSpikes();
    }

    /**
     * Función encargada de retraer los pinchos.
     */
    void retractSpikes()
    {
        transform.GetChild(0).transform.Translate(new Vector3(0, 0, -0.8f));
    }

    /*
     * Función encargada de sacar los pinchos.
     */
    void moveSpikes()
    {
        if (enabled && collisioned && !spikesOut)
        {
            spikesOut = true;
            transform.GetChild(0).transform.Translate(new Vector3(0, 0, 0.8f));
        }

        collisioned = false;
    }

    /*
     * Se encarga de eliminarse de la lista de eventos.
     */
    void OnDisable()
    {
        DelegateHandler.delegateHandler.onCharacterStepsOnTile -= moveSpikes;
    }

    /**
     * Evento de colisión. En este caso, si colisiona con el jugador, la trampa esta activada y los 
     * pinchos no están ya fuera, llama a la función del handler que se encarga del evento.
     */
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && enabled && !collisioned && !spikesOut)
        {
            collisioned = true;
            DelegateHandler.delegateHandler.CallOnCharacterStepsOnTile();
        }
    }
}
