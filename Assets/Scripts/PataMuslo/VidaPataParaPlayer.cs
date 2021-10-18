using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaPataParaPlayer : MonoBehaviour
{
    public int vidaPlayer = 10;
    public float tiempo = 0;
    public int tiempoPata = 5;

    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        diePata();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<VidaPlayer>().vida += vidaPlayer;
            Destroy(gameObject);
            Debug.Log("TocandoPataMuslo");
        }
    }

   void diePata()
    {
        tiempo = tiempo + Time.deltaTime;
        
        if(tiempo > tiempoPata)
        {
             Destroy(gameObject);
        }
        
    }
    
} 


