using UnityEngine;

public class DetectorGol : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pelota"))
        {
            Debug.Log("¡¡GOOOL!!");

            Marcador.instancia.GolLocal();

            ReiniciarJuego.instancia.ReiniciarPosiciones();
        }
    }
}