using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidad = 6f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(horizontal, 0, vertical);

        rb.MovePosition(
            rb.position + movimiento * velocidad * Time.fixedDeltaTime
        );

        if (movimiento != Vector3.zero)
        {
            transform.forward = movimiento;
        }
    }
}


