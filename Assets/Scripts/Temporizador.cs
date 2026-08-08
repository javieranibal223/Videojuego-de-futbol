using TMPro;
using UnityEngine;

public class Temporizador : MonoBehaviour
{
	public float tiempoInicial = 60f;
	public TMP_Text textoTiempo;
	public GameObject textoFinPartida;

	private float tiempo;
	private bool juegoTerminado = false;

	void Start()
	{
		tiempo = tiempoInicial;

		if (textoFinPartida != null)
		{
			textoFinPartida.SetActive(false);
		}
	}

	void Update()
	{
		if (!juegoTerminado)
		{
			tiempo -= Time.deltaTime;

			if (tiempo <= 0)
			{
				tiempo = 0;
				juegoTerminado = true;

				if (textoFinPartida != null)
				{
					textoFinPartida.SetActive(true);
				}
			}

			textoTiempo.text = "TIEMPO: " + Mathf.CeilToInt(tiempo);
		}
		else
		{
			if (Input.GetKeyDown(KeyCode.R))
			{
				ReiniciarPartida();
			}
		}
	}

	void ReiniciarPartida()
	{
		tiempo = tiempoInicial;
		juegoTerminado = false;

		if (textoFinPartida != null)
		{
			textoFinPartida.SetActive(false);
		}

		textoTiempo.text = "TIEMPO: " + Mathf.CeilToInt(tiempo);

		if (ReiniciarJuego.instancia != null)
		{
			ReiniciarJuego.instancia.ReiniciarPosiciones();
		}
	}
}