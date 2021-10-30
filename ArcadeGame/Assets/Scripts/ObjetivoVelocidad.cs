using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetivoVelocidad : Objetivo
{
    public bool reposicionar = true;
    public float velocidad;
    public float tiempo;
    public Material positivo;
    public Material negativo;

    void Start()
    {
        if (velocidad > 0)
        {
            this.GetComponent<Renderer>().material = positivo;
        }
        else
        {
            this.GetComponent<Renderer>().material = negativo;
        }
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var player = other.GetComponent<Player>();
            player.ModificarVelocidad(velocidad);
            player.ModificarTiempo(tiempo);
        }

        if (reposicionar)
        {
            base.OnTriggerEnter(other);
        }
    }

    public void ReposicionarNuevo()
    {
        base.Reposicionar();
    }
}
