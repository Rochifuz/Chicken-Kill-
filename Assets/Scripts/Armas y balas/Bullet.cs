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
}
