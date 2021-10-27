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
    void Die()
    {
       Destroy(gameObject);        
    }
    
    void Update()
    {
       vida = Mathf.Clamp(vida, 0, 100);
       barradeVida.fillAmount = vida / 100;
        if (vida == 0)
        {
            Ganar.show1();
            Die();
            Cursor.lockState = CursorLockMode.None;


        }
        
    }
    
}
