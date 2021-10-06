using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarArmaPersonaje : MonoBehaviour
{
    public AgarrarArmas agarrarArma;
    public int numeroArma;
    private int armaSeleccionada;
    // Start is called before the first frame update
    void Start()
    {
        agarrarArma = GameObject.FindGameObjectWithTag("Player").GetComponent<AgarrarArmas>();
        armaSeleccionada = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerActions>().numeroArma;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            armaSeleccionada = numeroArma;
            agarrarArma.ActivarArmar(numeroArma);
            Destroy(gameObject);
        }
    }
}
