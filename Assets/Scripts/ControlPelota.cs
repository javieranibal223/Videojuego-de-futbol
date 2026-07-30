using UnityEngine;

public class ControlPelota : MonoBehaviour
{
    public Transform jugador;          // Referencia al jugador
    public float distanciaControl = 1.2f;
    public float fuerzaPateo = 12f;

    private Rigidbody rb;
    private bool tienePelota = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float distancia = Vector3.Distance(transform.position, jugador.position);

        // Si el jugador está cerca, controla la pelota
        if (distancia <= distanciaControl)
        {
            tienePelota = true;
        }
        else
        {
            tienePelota = false;
        }

        // Patear con Espacio
        if (tienePelota && Input.GetKeyDown(KeyCode.Space))
        {
            rb.isKinematic = false;

            Vector3 direccion = jugador.forward;

            rb.AddForce(direccion * fuerzaPateo, ForceMode.Impulse);

            tienePelota = false;
        }
    }

    void FixedUpdate()
    {
        if (tienePelota)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            Vector3 posicionDeseada =
                jugador.position +
                jugador.forward * 0.8f;

            posicionDeseada.y = 0.25f;

            transform.position = Vector3.Lerp(
                transform.position,
                posicionDeseada,
                12f * Time.fixedDeltaTime
            );
        }
    }
}
