using UnityEngine;
using TMPro;

public class Cronometro : MonoBehaviour
{
    public float tiempoInicial = 60f;
    public TMP_Text textoTiempo;

    private float tiempoActual;
    private bool partidoActivo = true;

    void Start()
    {
        tiempoActual = tiempoInicial;
        ActualizarTexto();
    }

    void Update()
    {
        if (!partidoActivo)
            return;

        tiempoActual -= Time.deltaTime;

        if (tiempoActual <= 0)
        {
            tiempoActual = 0;
            partidoActivo = false;

            ActualizarTexto();
            FinDelPartido();

            return;
        }

        ActualizarTexto();
    }

    void ActualizarTexto()
    {
        int segundos = Mathf.CeilToInt(tiempoActual);

        if (textoTiempo != null)
        {
            textoTiempo.text = "TIEMPO: " + segundos;
        }
    }

    void FinDelPartido()
    {
        Debug.Log("FIN DEL PARTIDO");
    }
}