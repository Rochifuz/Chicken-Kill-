using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//script que se encuentra en Player
public class AgarrarArmas : MonoBehaviour
{
    public GameObject[] armas;
    public int numeroArmaActiva;

    // Start is called before the first frame update 

    public void ActivarArmar(int numero)//compara el numero de arma activa con el del array y la activa segun su numero
    {
        for(int i = 0; i < armas.Length; i++)
        {
            armas[i].SetActive(false);
        }

        armas[numero].SetActive(true);
    }
}
