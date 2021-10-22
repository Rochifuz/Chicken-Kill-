﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGenerador : MonoBehaviour
{
    public GameObject prefabEnemigos;
    public GameObject prefabEnemigos2;
    public int numeroEnemigos;
    // public int enemigoInicial = 1; // cant de enemigos en la primer oleada
    public int numeroMaxOleadas = 10; // la cant maxima de oleadas del nivel
    public int oleadaInicial = 1; //oleada en la que comienza a instanciar enemigos
    private int oleadaActual = 1; //en que oleada me encuentro

    // Start is called before the first frame update
    void Start()
    {
        GeneradorEnemigos(oleadaActual);
    }

    // Update is called once per frame
    void Update()
    {
        numeroEnemigos = FindObjectsOfType<Enemigos>().Length;

        if (numeroEnemigos == 0)
        {
            if (oleadaActual < numeroMaxOleadas)
            {                oleadaActual++;
                GeneradorEnemigos(oleadaActual);

                if (oleadaActual == 10)

                {
                    Time.timeScale = 0;
                    Ganar.show();
                    Cursor.lockState = CursorLockMode.None;
                }
            }
            
        }
        
    }

    void GeneradorEnemigos (int oleadas)
    {
        if (oleadas >= oleadaInicial)
        {


            for (int i = 0; i < incrementoEnemigos(oleadas - oleadaInicial+1); i++)
            {
                Instantiate(prefabEnemigos, DamePosicionGeneracion(), prefabEnemigos.transform.rotation);
            }
           
        }

        if (oleadas >= 2)
        {
            for (int i = 0; i < incrementoEnemigos(oleadas - oleadaInicial + 1); i++)
            {
                Instantiate(prefabEnemigos2, DamePosicionGeneracion(), prefabEnemigos2.transform.rotation);
            }
        }
    }

    int incrementoEnemigos (int oleadas)
    {
        if (oleadas > 15)
        {
            return oleadas^2;

        }
        else return oleadas * 2;
    }

    Vector3 DamePosicionGeneracion ()
    {
        float posXGeneracion = Random.Range(-99, -69);
        float posZGeneracion = Random.Range(-19, -50);

        Vector3 posAleatoria = new Vector3(posXGeneracion, 2, posZGeneracion);
    
        return posAleatoria;
    }
}
