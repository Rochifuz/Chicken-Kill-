using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pared : MonoBehaviour
{
    public int ronda;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ronda = GetComponent<ControlGenerador>().oleadaActual;
        if (ronda == 3)
        {
            Destroy(gameObject);
        }
    }
}
