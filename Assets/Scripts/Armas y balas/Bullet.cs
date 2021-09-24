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
    private void OnCollisionEnter(Collider other)
    {
      
        if ( other.gameObject.CompareTag("Enemigo"))
        {
            Rigidbody rbEnemigo = other.gameObject.GetComponent<Rigidbody>();
            Vector3 impacto = (other.transform.position - transform.position);
            rbEnemigo.AddForce(impacto * 5, ForceMode.Impulse);
        }
    }
}
