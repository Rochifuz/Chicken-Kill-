using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//este script se encuentra en generadorObjetos
public class ControlGenerador : MonoBehaviour
{
    public GameObject prefabEnemigos;
    public GameObject prefabEnemigos2;
    public int numeroEnemigos;
    // public int enemigoInicial = 1; // cant de enemigos en la primer oleada
    public int numeroMaxOleadas = 10; // la cant maxima de oleadas del nivel
    public int oleadaInicial = 1; //oleada en la que comienza a instanciar enemigos
    public int oleadaActual = 1; //en que oleada me encuentro
    int cantidadEnemigos = 1;//este es el entero de los enemigos instanciados
    // Start is called before the first frame update
    void Start()
    {
        GeneradorEnemigos(cantidadEnemigos, prefabEnemigos);//Esto cuenta cuantos enemigos hay instanciados y que prefab se utiliza
    }

    // Update is called once per frame
    void Update()
    {
        numeroEnemigos = FindObjectsOfType<Enemigos>().Length;

        if (numeroEnemigos == 0)
        {
            if (oleadaActual < numeroMaxOleadas)//mientras la oleada sea menor al maximo de oleadas se siguen invocando enemigos
            {
                oleadaActual++;
                cantidadEnemigos = incrementoEnemigos(oleadaActual - oleadaInicial + 1);
                if (oleadaActual >= 2)//si se alcanza la oleada dos se divide la invocacion de cada prefab en 2 para que la cantidad sea la correcta
                {
                    cantidadEnemigos = cantidadEnemigos / 2;
                }
                GeneradorEnemigos(cantidadEnemigos, prefabEnemigos);
                if (oleadaActual >= 2)//Aqui si se llega a la oleada 2 se comienzan a instanciar los otros enemigos
                {
                    GeneradorEnemigos(cantidadEnemigos, prefabEnemigos2);
                }
                if (oleadaActual == numeroMaxOleadas)//Esta funcion dice que si se alcanza el numero max de oleadas se gana el juego

                {
                    Ganar.show();
                }
            }
            if (oleadaActual == 2)
            {
                Destroy(GameObject.FindGameObjectWithTag("PARED"));
            }

        }

    }

    void GeneradorEnemigos(int cantidadEnemigos, GameObject instanciaEnemigo)
    {


        for (int i = 0; i < cantidadEnemigos; i++)// esta funcion instancia los enemigos con un ciclo for y en el lugar que se le da
        {
            Instantiate(instanciaEnemigo, DamePosicionGeneracion(), instanciaEnemigo.transform.rotation);
            if(oleadaActual > 2)
            {
                Instantiate(instanciaEnemigo, DamePosicionGeneracion2(), instanciaEnemigo.transform.rotation);
            }
        }


    }

    int incrementoEnemigos(int oleadas)//esta funcion multiplica la cantidad de enemigos segun la oleada en la que se encuentra
    {
        if (oleadas > 15)
        {
            return oleadas ^ 2;

        }
        else return oleadas * 2;
    }

    Vector3 DamePosicionGeneracion()//Esta funcion da la posicion en donde se instancian los enemigos
    {
      
            float posXGeneracion = Random.Range(-99, -69);
            float posZGeneracion = Random.Range(-19, -50);
            Vector3 posAleatoria = new Vector3(posXGeneracion, 2, posZGeneracion);
            return posAleatoria;
       

    }
    Vector3 DamePosicionGeneracion2()//Esta funcion da la posicion en donde se instancian los enemigos
    {

        float posXGeneracion2 = Random.Range(-61, -32);
        float posZGeneracion2 = Random.Range(-17, -52);
        Vector3 posAleatoria2 = new Vector3(posXGeneracion2, 2, posZGeneracion2);
        return posAleatoria2;


    }
}