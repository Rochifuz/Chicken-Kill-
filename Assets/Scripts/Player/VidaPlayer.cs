using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaPlayer : MonoBehaviour
{
    public float vida = 100;

    public Image barradeVida;

    void Die()
    {
       Destroy(gameObject);        
    }


<<<<<<< Updated upstream
=======
    void Die()
    {
        Destroy(gameObject);
    }

>>>>>>> Stashed changes
    void Update()
    {
       vida = Mathf.Clamp(vida, 0, 100);
       barradeVida.fillAmount = vida / 100;
        if (vida == 0)
        {
            Ganar.show1();
            Die();
        }
    }
}
