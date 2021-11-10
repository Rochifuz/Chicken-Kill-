using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//este script se encuentra en el gameobject de la bala o bullet
public class Bullet : MonoBehaviour
{ 

   public float speed = 8f;
   public float lifeDuration = 2f;
   float lifeTimer;
   public int attack = 5;

   public bool shootByPlayer;//un bool para saber si es el jugador quien disparo la bala o la gallina
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

        if ( other.gameObject.CompareTag("Enemigo"))   // si collisiona con el tag enemigo.
        {
            Rigidbody rbEnemigo = other.gameObject.GetComponent<Rigidbody>();      
            Vector3 impacto = (other.transform.position - transform.position);
            rbEnemigo.AddForce(impacto * 2, ForceMode.Impulse);//esto hace que empuje un poco a las gallinas cuando las impacta las balas
        }
        // esto dice a quien golpea la bala
        Debug.Log("Bullet golpea = " + other.name);

        IDamage damage = other.GetComponent<IDamage>();
        if(damage != null)
        {//aca se define quien golpea y cuanto daño realiza por medio de la interfaz
            damage.DoDamage(attack);
        }
        gameObject.SetActive(false);
    }
}
