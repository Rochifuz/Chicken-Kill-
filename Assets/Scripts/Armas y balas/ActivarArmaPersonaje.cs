using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Este script se encuentra en el GameObject del Player
public class ActivarArmaPersonaje : MonoBehaviour
{
    public AgarrarArmas agarrarArma;
    public int numeroArma;
    // Start is called before the first frame update
    
  
        //esta funcion se encarga de que cuando colisiona el player con el gameobject del arma se le active y destruya la que ya tiene
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            agarrarArma = other.GetComponent<AgarrarArmas>();//Esta obtiene el numero del arma con la que colisiona
            agarrarArma.ActivarArmar(numeroArma); //Esta activa el arma segun su numero
            agarrarArma.numeroArmaActiva = numeroArma; //esta me dice que arma activa tengo en la mano
            Destroy(gameObject); //Esto destruye el gameobject del piso
        }
    }
}
