using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovimientoPelota : MonoBehaviour
{
    public float velocidad = 3f;
    public float limiteIzquierdo = -4f;
    public float limiteDerecho = 4f;

    private Rigidbody rb;
    private int direccion = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 velocidadActual = rb.linearVelocity;
        velocidadActual.x = velocidad * direccion;
        rb.linearVelocity = velocidadActual;

        if (transform.position.x >= limiteDerecho)
            direccion = -1;

        if (transform.position.x <= limiteIzquierdo)
            direccion = 1;
    }

    public void ReiniciarMovimiento()
    {
        direccion = 1;

        rb.linearVelocity = new Vector3(
            velocidad,
            rb.linearVelocity.y,
            rb.linearVelocity.z
        );

        rb.angularVelocity = Vector3.zero;
    }
}