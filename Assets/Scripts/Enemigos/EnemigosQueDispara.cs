using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//este script se encuentra en el prefab chicken que es la segunda gallina
public class EnemigosQueDispara : MonoBehaviour, IDamage
{
    public GameObject target;
    public Transform weapon;
    float distanceToTarget;
    public int daño = 10;
    public float distanciaDisparo = 10f;
    public float intervaloDisparo = 2f;
    float shootTime;
    public int life = 15;//vida de la gallina

    public bool shootByPlayer;

    NavMeshAgent agent;

    public GameObject PataMuslo;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");
        shootTime = intervaloDisparo;

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
    void Die()//aca se destruye la gallina y se instancia la pata en su lugar
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
        agent.SetDestination(target.transform.position); //para que la gallina nos persiga

        if (transform.position.y < -10)
        {
            Destroy(gameObject); //se destruye la gallina si se cae 
        }
        ShootControl();
    }

    void ShootControl()//aqui se controla el disparo junto al intervalo de disparo y la distancia que hay con el player
    {
        shootTime -= Time.deltaTime;
        if(shootTime < 0)
        {
            if(distanceToTarget < distanciaDisparo)
            {
                shootTime = intervaloDisparo; //tiempo entre bala y bala
                GameObject bullet2 = ObjectPooling2.instance.GetBullet2(false);//aqui se instancia la bala y dice que es del enemigo al decir false
                bullet2.transform.position = weapon.position;//se instancia en el arma que es un gameobject invisible
                bullet2.transform.LookAt(target.transform.position); //dispara a la posicion del player              
            }
        }
    }
}