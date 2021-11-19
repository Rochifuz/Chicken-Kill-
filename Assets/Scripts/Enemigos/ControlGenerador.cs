using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
//este script se encuentra en generadorObjetos
public class ControlGenerador : MonoBehaviourPun
{
    public GameObject prefabEnemigos;//Enemigo comun
    public GameObject prefabEnemigos2;//Enemigo cque disapara
    public GameObject prefabEnemigos3;//Enemigo boss
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
        GeneradorEnemigos2(oleadaInicial, prefabEnemigos3);//Te crea solo un prefab del boss en la posicion final
    }

    // Update is called once per frame
    void Update()
    {
        
        numeroEnemigos = FindObjectsOfType<Enemigos>().Length;

        if (numeroEnemigos == 0)
        {
            if (oleadaActual < numeroMaxOleadas)//mientras la oleada sea menor al maximo de oleadas se siguen invocando enemigos
            {
                Debug.Log("Es la oleada: "+oleadaActual);
                oleadaActual++;
                cantidadEnemigos = incrementoEnemigos(oleadaActual - oleadaInicial + 1);
                if (oleadaActual >= 1)//si se alcanza la oleada dos se divide la invocacion de cada prefab en 2 para que la cantidad sea la correcta
                {
                    cantidadEnemigos = cantidadEnemigos / 2;
                }
                GeneradorEnemigos(cantidadEnemigos, prefabEnemigos);
                if (oleadaActual >= 1)//Aqui si se llega a la oleada 2 se comienzan a instanciar los otros enemigos
                {
                    GeneradorEnemigos(cantidadEnemigos, prefabEnemigos2);
                }
                if(oleadaActual >= 2)//Aqui aparece el Boss
                {
                    GeneradorEnemigos2(1,prefabEnemigos3);
                }
                if (oleadaActual == numeroMaxOleadas)//Esta funcion dice que si se alcanza el numero max de oleadas se gana el juego

                {
                    Ganar.show();
                }
            }
            if (oleadaActual == 2)//Funcion que te destruye las paredes
            {
                PhotonNetwork.Destroy(GameObject.FindGameObjectWithTag("PARED"));
            }

            if (oleadaActual == 5)//Funcion que te destruye las paredes
            {
                PhotonNetwork.Destroy(GameObject.FindGameObjectWithTag("PARED 2"));
            }

            if (oleadaActual == 8)//Funcion que te destruye las paredes
            {
                PhotonNetwork.Destroy(GameObject.FindGameObjectWithTag("PARED 3"));
            }

            if (oleadaActual == 8)//Funcion que te destruye las paredes
            {
                PhotonNetwork.Destroy(GameObject.FindGameObjectWithTag("PARED 4"));
            }

        }

    }

    void GeneradorEnemigos(int cantidadEnemigos, GameObject instanciaEnemigo)
    {


        for (int i = 0; i < cantidadEnemigos; i++)// esta funcion instancia los enemigos con un ciclo for y en el lugar que se le da
        {
            PhotonNetwork.Instantiate(instanciaEnemigo.name, DamePosicionGeneracion(), instanciaEnemigo.transform.rotation);
            if(oleadaActual > 1)
            {
                PhotonNetwork.Instantiate(instanciaEnemigo.name, DamePosicionGeneracion2(), instanciaEnemigo.transform.rotation);
            }

            if(oleadaActual > 2)
            {
                PhotonNetwork.Instantiate(instanciaEnemigo.name, DamePosicionGeneracion3(), instanciaEnemigo.transform.rotation);
            }
        }
    }

    void GeneradorEnemigos2(int oleadaInicial, GameObject instanciaEnemigo2)//Esta funcion es la que te instancia el boss
    {
        if(oleadaActual > 2)
        {
            PhotonNetwork.Instantiate(instanciaEnemigo2.name, DamePosicionGeneracion4(), instanciaEnemigo2.transform.rotation);
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

    Vector3 DamePosicionGeneracion3()//Esta funcion da la posicion en donde se instancian los enemigos
    {

        float posXGeneracion3 = Random.Range(-30, -6);
        float posZGeneracion3 = Random.Range(-23, 39);
        Vector3 posAleatoria3 = new Vector3(posXGeneracion3, 2, posZGeneracion3);
        return posAleatoria3;


    }

    Vector3 DamePosicionGeneracion4()//Esta funcion da la posicion en donde se instancian los enemigos
    {

    
        Vector3 posAleatoria4 = new Vector3(-64, 2, 17);
        return posAleatoria4;


    }

    private void OnGUI()
    {
        GUI.contentColor = Color.black;
        GUI.Label(new Rect(1250, 10, 500, 500), "Oleadas: "+ oleadaActual);

    }
}