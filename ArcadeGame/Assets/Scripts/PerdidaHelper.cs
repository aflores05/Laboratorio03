using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerdidaHelper : MonoBehaviour
{
    public string EscenaPortada;
    public Text PuntajeTotal;
    public InputField inicialesJugador;

    public int[] puntajes;
    public string[] puntajesNombres;

    private int pivote;
    private int temp;

    private string pivoteNombre;
    private string tempNombre;

    private int i;

    public void GuardarDatosDiscoDuro()
    {
        puntajes = new int[3];
        puntajesNombres = new string[3];

        RecuperarDatos();

        pivote = GameManager.instancia.ObtenerPuntaje();

        if (pivote > puntajes[0])
        {
            tempNombre = puntajesNombres[1]; // nombre
            temp = puntajes[1]; // puntaje

            puntajesNombres[1] = puntajesNombres[0];
            puntajes[1] = puntajes[0];

            puntajesNombres[0] = pivoteNombre;
            puntajes[0] = pivote;

            pivoteNombre = tempNombre;
            pivote = temp;
        }
        if (pivote > puntajes[1])
        {
            tempNombre = puntajesNombres[2];
            temp = puntajes[2];

            puntajesNombres[2] = puntajesNombres[1];
            puntajes[2] = puntajes[1];

            puntajesNombres[1] = pivoteNombre;
            puntajes[1] = pivote;

            pivoteNombre = tempNombre;
            pivote = temp;
        }
        if (pivote > puntajes[2])
        {
            puntajesNombres[2] = pivoteNombre;
            puntajes[2] = pivote;
        }

        GuardarDatos();
    }

    private void Start()
    {
        PuntajeTotal.text = GameManager.instancia.ObtenerPuntaje().ToString();   
    }

    private void RecuperarDatos()
    {
        puntajes[0] = PlayerPrefs.GetInt("Pos01", 0);
        puntajes[1] = PlayerPrefs.GetInt("Pos02", 0);
        puntajes[2] = PlayerPrefs.GetInt("Pos03", 0);

        puntajesNombres[0] = PlayerPrefs.GetString("PosNombres01", "UCR");
        puntajesNombres[1] = PlayerPrefs.GetString("PosNombres02", "UCR");
        puntajesNombres[2] = PlayerPrefs.GetString("PosNombres03", "UCR");
    }

    private void GuardarDatos()
    {
        PlayerPrefs.SetInt("Pos01", puntajes[0]);
        PlayerPrefs.SetInt("Pos02", puntajes[1]);
        PlayerPrefs.SetInt("Pos03", puntajes[2]);

        PlayerPrefs.SetString("Pos01", puntajesNombres[0]);
        PlayerPrefs.SetString("Pos02", puntajesNombres[1]);
        PlayerPrefs.SetString("Pos03", puntajesNombres[2]);
    }

    public void VolverPortada()
    {
        pivoteNombre = inicialesJugador.text;
 
        GuardarDatosDiscoDuro();

        try
        {
            GameManager.instancia.CambiarEscena(EscenaPortada);
        }
        catch (System.Exception ex)
        {
            Debug.Log("Se te olvidó poner el GameManager en la escena");
        }
    }
}
