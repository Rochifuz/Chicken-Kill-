using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ganar : MonoBehaviour
{
    public GameObject Cartelganar;
    public static GameObject ganarStatic;
    public GameObject CartelPerder;
    public static GameObject perderStatic;

    public static GameObject botonJugarstatic;
    public static GameObject botonPerderstatic;
    public GameObject botonJugar;
    public GameObject botonPerder;
    // Start is called before the first frame update
    void Start()
    {
        
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
    {
        Ganar.ganarStatic.gameObject.SetActive(true);
        Ganar.botonJugarstatic.gameObject.SetActive(true);
        Ganar.botonPerderstatic.gameObject.SetActive(true);
    }

    public static void show1()
    {
        Ganar.perderStatic.gameObject.SetActive(true);
        Ganar.botonPerderstatic.gameObject.SetActive(true);
        Ganar.botonJugarstatic.gameObject.SetActive(true);
    }
    
    public static void show2()
    {
        Ganar.botonJugarstatic.gameObject.SetActive(true);
        Ganar.botonPerderstatic.gameObject.SetActive(true);
    }
    
}
