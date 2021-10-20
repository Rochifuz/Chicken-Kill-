using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigosQueDispara : MonoBehaviour, IDamage
{
    public GameObject target;
    public Transform weapon;
    float distanceToTarget;
    public float distanciaDisparo = 10f;
    public float intervaloDisparo = 2f;
    float tiempoDisparo;


    public int daño = 10;

    public int life = 15;

    public bool shootByPlayer;

    NavMeshAgent agent;

    public GameObject PataMuslo;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");
        tiempoDisparo = intervaloDisparo;

    }
    // este codigo es el daño de la bala a las gallinas
    public void DoDamage(int vld, bool isPlayer)
    {//aqui se muestra cuanto daño le hemos hecho a la gallina y la funcion para restarle vida y que se destruya
        Debug.Log("Daño hecho = " + vld + " isPlayer = " + isPlayer);
        if (isPlayer == true)
        {
            life -= vld;
            if (life < 0)
            {
                Die();
            }
        }
    }
    //funcion de muerte de la gallina
    void Die()
    {
        Destroy(gameObject);
        Instantiate(PataMuslo, transform.position, transform.rotation);

    }
    // Update is called once per frame
    void Update()
    {
        //el posNoRot es para que las gallinas no giren todo su cuerpo hacia nosotros
        Vector3 posNoRot = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
        transform.LookAt(posNoRot); //para que la gallina nos mire

        distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
        //distance calcula la distancia entre la gallina y nosotros
        ShootControl();

        agent.SetDestination(target.transform.position); //para que la gallina nos persiga

        if (transform.position.y < -10)
        {
            Destroy(gameObject); //se destruye la gallina si se cae 
        }
    }

    void ShootControl()
    {
        tiempoDisparo -= Time.deltaTime;
        if(tiempoDisparo < 0)
        {
            if( distanceToTarget < distanciaDisparo)
            {
                tiempoDisparo = intervaloDisparo;
                GameObject bullet = ObjectPooling.instance.GetBullet(false);
                bullet.transform.position = weapon.position;
                bullet.transform.LookAt(target.transform.position);
            }
        }
    }

}