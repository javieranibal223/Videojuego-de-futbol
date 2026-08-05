using UnityEngine;

public class ReiniciarJuego : MonoBehaviour
{
    public static ReiniciarJuego instancia;

    public Transform jugador;
    public Transform pelota;

    private Vector3 posicionInicialJugador;
    private Vector3 posicionInicialPelota;

    private Rigidbody rbPelota;

    void Awake()
    {
        instancia = this;
    }

    void Start()
    {
        posicionInicialJugador = jugador.position;
        posicionInicialPelota = pelota.position;

        rbPelota = pelota.GetComponent<Rigidbody>();
    }

    public void ReiniciarPosiciones()
    {
        rbPelota.linearVelocity = Vector3.zero;
        rbPelota.angularVelocity = Vector3.zero;

        jugador.position = posicionInicialJugador;
        pelota.position = posicionInicialPelota;
    }
}