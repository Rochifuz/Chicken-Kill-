using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGenerador : MonoBehaviour
{
    public GameObject prefabEnemigos;
    // Start is called before the first frame update
    void Start()
    {
        GeneradorEnemigos();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GeneradorEnemigos ()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(prefabEnemigos, DamePosicionGeneracion(), prefabEnemigos.transform.rotation);
        }
    }

    Vector3 DamePosicionGeneracion ()
    {
        float posXGeneracion = Random.Range(120, 150);
        float posZGeneracion = Random.Range(750, 870);

        Vector3 posAleatoria = new Vector3(posXGeneracion, 2, posZGeneracion);
    
        return posAleatoria;
    }
}
