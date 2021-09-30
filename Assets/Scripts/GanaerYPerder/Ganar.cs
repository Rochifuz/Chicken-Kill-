using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ganar : MonoBehaviour
{
    public GameObject Cartelganar;
    public static GameObject ganarStatic;
    public GameObject CartelPerder;
    public static GameObject perderStatic;
    // Start is called before the first frame update
    void Start()
    {
        
            Ganar.ganarStatic = Cartelganar;
        Ganar.ganarStatic.gameObject.SetActive(false);

        Ganar.perderStatic = CartelPerder;
        Ganar.perderStatic.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void show()
    {
        Ganar.ganarStatic.gameObject.SetActive(true);
    }

    public static void show1()
    {
        Ganar.perderStatic.gameObject.SetActive(true);
    }
}
