using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarArmaPersonaje : MonoBehaviour
{
    public AgarrarArmas agarrarArma;
    public int numeroArma;
    // Start is called before the first frame update
    
  

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            agarrarArma = other.GetComponent<AgarrarArmas>();
            agarrarArma.ActivarArmar(numeroArma);
            agarrarArma.numeroArmaActiva = numeroArma;
            Destroy(gameObject);
        }
    }
}
