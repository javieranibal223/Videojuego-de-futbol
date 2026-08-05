using UnityEngine;

public class SeguirCamara : MonoBehaviour
{
    public Transform jugador;

    public Vector3 offset =
        new Vector3(0f, 6f, -8f);

    public float suavizado = 5f;

    void LateUpdate()
    {
        Vector3 destino =
            jugador.position +
            jugador.TransformDirection(offset);

        transform.position = Vector3.Lerp(
            transform.position,
            destino,
            suavizado * Time.deltaTime
        );

        transform.LookAt(
            jugador.position + Vector3.up * 1.5f
        );
    }
}