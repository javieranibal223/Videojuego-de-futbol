using UnityEngine;

public class ControlPelota : MonoBehaviour
{
    public Transform jugador;
    public float distanciaControl = 1.2f;
    public float distanciaFrente = 0.8f;
    public float velocidadSeguimiento = 8f;
    public float fuerzaPase = 10f;

    private Rigidbody rb;
    private bool controlando = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (controlando && Input.GetKeyDown(KeyCode.Space))
        {
            Patear();
        }
    }

    void FixedUpdate()
    {
        float distancia = Vector3.Distance(transform.position, jugador.position);

        controlando = distancia <= distanciaControl;

        if (controlando)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            Vector3 destino = jugador.position + jugador.forward * distanciaFrente;
            destino.y = 0.25f;

            transform.position = Vector3.Lerp(
                transform.position,
                destino,
                velocidadSeguimiento * Time.fixedDeltaTime
            );
        }
    }

    void Patear()
    {
        controlando = false;

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        rb.AddForce(jugador.forward * fuerzaPase, ForceMode.Impulse);
    }
}