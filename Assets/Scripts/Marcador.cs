using UnityEngine;
using TMPro;

public class Marcador : MonoBehaviour
{
    public static Marcador instancia;

    [Header("Marcador")]
    public int golesLocal = 0;
    public int puntos = 0;
    public int combo = 0;

    [Header("Puntuación")]
    public int puntosPorGol = 100;

    [Header("UI")]
    public TMP_Text textoGoles;
    public TMP_Text textoPuntos;
    public TMP_Text textoCombo;

    private void Awake()
    {
        instancia = this;
    }

    private void Start()
    {
        ActualizarMarcador();
    }

    public void GolLocal()
    {
        golesLocal++;
        combo++;

        int puntosGanados = puntosPorGol * combo;
        puntos += puntosGanados;

        Debug.Log("¡¡GOOOL!!");
        Debug.Log("Goles: " + golesLocal);
        Debug.Log("Combo: x" + combo);
        Debug.Log("Puntos ganados: " + puntosGanados);
        Debug.Log("Puntos totales: " + puntos);

        ActualizarMarcador();
    }

    public void PerderCombo()
    {
        combo = 0;

        ActualizarMarcador();
    }

    private void ActualizarMarcador()
    {
        if (textoGoles != null)
        {
            textoGoles.text = "GOLES: " + golesLocal;
        }

        if (textoPuntos != null)
        {
            textoPuntos.text = "PUNTOS: " + puntos;
        }

        if (textoCombo != null)
        {
            textoCombo.text = "COMBO x" + combo;
        }
    }
}