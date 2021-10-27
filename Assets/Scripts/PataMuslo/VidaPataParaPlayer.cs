using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//este script se encuentra en el gambeObject PataMuslo
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
        diePata();//destruye la pata cuando pasa el tiempo


    }
    private void OnCollisionEnter(Collision collision)//cuando el jugador colisiona con la pata se le suma vida
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<VidaPlayer>().vida += vidaPlayer;//suma la vida al jugador
            Destroy(gameObject);
            Debug.Log("TocandoPataMuslo");
        }
    }

   void diePata()//esta funcion se encarga de que desaparezca la pata cuando pasa el tiempo
    {
        tiempo = tiempo + Time.deltaTime;
        
        if(tiempo > tiempoPata)
        {
             Destroy(gameObject);
        }
        
    }
    
} 


