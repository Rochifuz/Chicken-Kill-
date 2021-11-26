using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//este script se encuentra en el player
public class VidaPlayer : MonoBehaviour
{
    public float vida = 100;

    public Image barradeVida;

   

    //funcion de muerte
    public void Die()
    {
        Destroy(gameObject);
       
        
    }
    
    void Update()
    {
       vida = Mathf.Clamp(vida, 0, 100);//Esta funcion llena un valor entre un minimo y maximo
       barradeVida.fillAmount = vida / 100;//Ingresa a la propiedad de barra de vida llamada fill amount y calcula la vida actual sobre la vida maxima
        if (vida == 0 && GetComponent<VidaPlayer2>().vida == 0)
        {
            //Aca te va a mostrar si es que tu vida llega a 0, un cartel que perdiste y destruye el Game Object
            Ganar.show1();
            Die();
            Cursor.lockState = CursorLockMode.None;


        }
        

    }
    
}
