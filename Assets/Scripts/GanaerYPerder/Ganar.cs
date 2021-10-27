using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Este script se encuentra en ManejadorGanarJuego
public class Ganar : MonoBehaviour
{
    public GameObject Cartelganar;//Cartel de cuando ganas
    public static GameObject ganarStatic;
    public GameObject CartelPerder;//Cartel de cuando perdes
    public static GameObject perderStatic;

    public static GameObject botonJugarstatic;
    public static GameObject botonPerderstatic;
    public GameObject botonJugar;//Cartel de cuando volver a jugar
    public GameObject botonPerder;//Cartel de cuando queres salir del juego

    // Start is called before the first frame update
    void Start()
    {
        //Arrancan todos en falso
            Ganar.ganarStatic = Cartelganar;
        Ganar.ganarStatic.gameObject.SetActive(false);

        Ganar.perderStatic = CartelPerder;
        Ganar.perderStatic.gameObject.SetActive(false);

        Ganar.botonJugarstatic = botonJugar;
        Ganar.botonJugarstatic.gameObject.SetActive(false);

        Ganar.botonPerderstatic = botonPerder;
        Ganar.botonPerderstatic.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void show()
    //Esta funcion hace que te muestre un cartel cuando ganas
    {
        Ganar.ganarStatic.gameObject.SetActive(true);
        Ganar.botonJugarstatic.gameObject.SetActive(true);
        Ganar.botonPerderstatic.gameObject.SetActive(true);
    }

    public static void show1()
    //Esta funcion hace que te muestre un cartel cuando perdes
    {
        Ganar.perderStatic.gameObject.SetActive(true);
        Ganar.botonPerderstatic.gameObject.SetActive(true);
        Ganar.botonJugarstatic.gameObject.SetActive(true);
    }
    
    public static void show2()
    //Esta funcion hace que te muestre un cartel cuando pones pausa
    {
        Ganar.botonJugarstatic.gameObject.SetActive(true);
        Ganar.botonPerderstatic.gameObject.SetActive(true);
    }
    
}
