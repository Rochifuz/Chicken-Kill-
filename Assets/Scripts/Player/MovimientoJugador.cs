using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    
    public float velocidadRot = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float entradaHor = Input.GetAxis("Horizontal2");
        transform.Rotate(Vector3.up, velocidadRot * Time.deltaTime * entradaHor);
        
    }
}
