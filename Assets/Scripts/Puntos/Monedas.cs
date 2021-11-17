using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monedas : MonoBehaviour
{
    public float x = 0;
    public float y = 5;
    public float z = 0;

    public int puntosQueDa = 10;
    private void OnCollisionEnter(Collision collision)
    {
        
            collision.gameObject.GetComponent<PlayerActions>().incremento(puntosQueDa);
            Destroy(gameObject);
        
    }
    private void Update()
    {
        transform.Rotate(x, y, z);
    }
}
