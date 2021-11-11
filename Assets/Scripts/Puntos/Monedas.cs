using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monedas : MonoBehaviour
{
    PlayerActions jugador; 
    public int puntosQueDa = 10;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            jugador.GetComponent<PlayerActions>().incremento(puntosQueDa);
            Destroy(gameObject);
        }
    }
}
