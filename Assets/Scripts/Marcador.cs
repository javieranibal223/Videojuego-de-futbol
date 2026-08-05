using UnityEngine;

public class Marcador : MonoBehaviour
{
    public static Marcador instancia;

    public int golesLocal = 0;

    private void Awake()
    {
        instancia = this;
    }

    public void GolLocal()
    {
        golesLocal++;

        Debug.Log("¡¡GOOOL!!");
        Debug.Log("Marcador: " + golesLocal);
    }
}
