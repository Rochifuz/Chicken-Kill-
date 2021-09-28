using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarArmaPersonaje : MonoBehaviour
{
    public AgarrarArmas agarrarArma;
    public int numeroArma;
    // Start is called before the first frame update
    void Start()
    {
        agarrarArma = GameObject.FindGameObjectWithTag("Player").GetComponent<AgarrarArmas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            agarrarArma.ActivarArmar(numeroArma);
            Destroy(gameObject);
        }
    }
}
