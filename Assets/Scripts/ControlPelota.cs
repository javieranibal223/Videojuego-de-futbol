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
        if (!controlando)
        {
            float distancia = Vector3.Distance(
                transform.position,
                jugador.position
            );

            if (distancia <= distanciaControl)
            {
                controlando = true;
            }
        }

        if (controlando)
        {
            Vector3 destino =
                jugador.position +
                jugador.forward * distanciaFrente;

            Vector3 nuevaPosicion = transform.position;

            nuevaPosicion.z = Mathf.Lerp(
                transform.position.z,
                destino.z,
                velocidadSeguimiento * Time.fixedDeltaTime
            );

            nuevaPosicion.y = 0.25f;

            transform.position = nuevaPosicion;
        }
    }

    void Patear()
    {
        controlando = false;

        rb.AddForce(
            jugador.forward * fuerzaPase,
            ForceMode.Impulse
        );
    }
}