using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//este script se encuentra en el gameobject de los huevos o bullet2
public class Bullet3 : MonoBehaviour
{ 

   public float speed = 8f;
   public float lifeDuration = 2f;
   float lifeTimer;
   public int attack2 = 10;

   public bool shootByPlayer2;//un bool para saber si es el jugador quien disparo la bala o la gallina
    //duracion de la bala
   private void OnEnable()
   {
       lifeTimer = lifeDuration;
   }
    //si el lifeTimer es menor a cero quiere decir que la bala no existe o no esta activada
   private void Update()
   {
       lifeTimer -= Time.deltaTime;
       if(lifeTimer <= 0)
       {
           gameObject.SetActive(false);
       }
    }
    //calcula la velocidad de la bala
    private void FixedUpdate()
    {
        transform.position += transform.forward * speed * Time.fixedDeltaTime;
    }

    
    
    // cuando la bala impacte con el tag enemigo , se le agregue una fuerza de impacto.
    private void OnTriggerEnter (Collider other)

    {
        // esto dice a quien golpea la bala
        Debug.Log("Bullet golpea = " + other.name);

        IDamage2 damage1 = other.GetComponent<IDamage2>();
        if(damage1 != null)
        {//aca se define quien golpea y cuanto daño realiza por medio de la interfaz
            damage1.DoDamage2(attack2, shootByPlayer2);
        }
        gameObject.SetActive(false);
    }
}


