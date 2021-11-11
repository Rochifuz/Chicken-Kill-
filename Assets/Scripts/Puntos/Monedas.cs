using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monedas : MonoBehaviour
{
    
    public int puntosQueDa = 10;
    private void OnCollisionEnter(Collision collision)
    {
        
            collision.gameObject.GetComponent<PlayerActions>().incremento(puntosQueDa);
            Destroy(gameObject);
        
    }
}
