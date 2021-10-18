using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaPataParaPlayer : MonoBehaviour
{
    public int vidaPlayer = 10;

    public float tiempo = 0;
    public GameObject PrefabPataMuslo;
    // Start is called before the first frame update

    public void TiempoDePataMuslo()
    {
        tiempo = tiempo + Time.time;
        while (tiempo == 10)
        {
            
            Destroy(PrefabPataMuslo);
            tiempo = 0;
        }
        
    }

    void Start()
    {
        PrefabPataMuslo = GetComponent<Enemigos>().PataMuslo;
    }

    // Update is called once per frame
    void Update()
    {
        
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

    
} 


