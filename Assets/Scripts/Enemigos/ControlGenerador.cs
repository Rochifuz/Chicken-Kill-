using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGenerador : MonoBehaviour
{
    public GameObject prefabEnemigos;
    public int numeroEnemigos;
    public int numeroOleada = 1;

    // Start is called before the first frame update
    void Start()
    {
        GeneradorEnemigos(numeroOleada);
    }

    // Update is called once per frame
    void Update()
    {
        numeroEnemigos = FindObjectsOfType<Enemigos>().Length;

        if (numeroEnemigos == 0)
        {
            numeroOleada++;
            GeneradorEnemigos(numeroOleada);
        }
    }

    void GeneradorEnemigos (int enemigosAGenerar)
    {
        for (int i = 0; i < enemigosAGenerar; i++)
        {
            Instantiate(prefabEnemigos, DamePosicionGeneracion(), prefabEnemigos.transform.rotation);
        }
    }

    Vector3 DamePosicionGeneracion ()
    {
        float posXGeneracion = Random.Range(-99, -30);
        float posZGeneracion = Random.Range(-16, -54);

        Vector3 posAleatoria = new Vector3(posXGeneracion, 2, posZGeneracion);
    
        return posAleatoria;
    }
}
