using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos : MonoBehaviour
{
    public float velocidad = 3;
    private Rigidbody rbEnemigo;
    private GameObject jugador;
    // Start is called before the first frame update
    void Start()
    {
        rbEnemigo = GetComponent<Rigidbody>();
        jugador = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vectorAlObjetivo = (jugador.transform.position - transform.position).normalized;

        rbEnemigo.AddForce(vectorAlObjetivo * velocidad);
    }
}
