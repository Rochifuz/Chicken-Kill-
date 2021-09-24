using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   public float speed = 8f;
   public float lifeDuration = 2f;
   float lifeTimer;

   private void Start()
   {
       lifeTimer = lifeDuration;
   }

   private void Update()
   {
       lifeTimer -= Time.deltaTime;
       if(lifeTimer <= 0)
       {
           gameObject.SetActive(false);
       }
    }

    private void FixedUpdate()
    {
        transform.position += transform.forward * speed * Time.fixedDeltaTime;
    }

    
    
    // cuando la bala impacte con el tag enemigo , se le agregue una fuerza de impacto.
    private void OncollisionEnter (Collider other)

    {
      
        if ( other.gameObject.CompareTag("Enemigo"))   // si collisiona con el tag enemigo.
        {
            Rigidbody rbEnemigo = other.gameObject.GetComponent<Rigidbody>(); 
            Vector3 impacto = (other.transform.position - transform.position);
            rbEnemigo.AddForce(impacto * 10, ForceMode.Impulse);
        }
    }
}
