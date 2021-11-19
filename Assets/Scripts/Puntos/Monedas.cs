using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Monedas : MonoBehaviourPun
{
    public float x = 0;
    public float y = 5;
    public float z = 0;

    public int puntosQueDa = 10;
    private void OnCollisionEnter(Collision collision)
    {
        
            collision.gameObject.GetComponent<PlayerActions>().incremento(puntosQueDa);
            PhotonNetwork.Destroy(gameObject);
        
    }
    private void Update()
    {
        transform.Rotate(x, y, z);
    }
}
