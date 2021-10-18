using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarrarArmas : MonoBehaviour
{
    public GameObject[] armas;
    public int numeroArmaActiva;

    // Start is called before the first frame update 

    public void ActivarArmar(int numero)
    {
        for(int i = 0; i < armas.Length; i++)
        {
            armas[i].SetActive(false);
        }

        armas[numero].SetActive(true);
    }
}
