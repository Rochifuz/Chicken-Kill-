using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//script que se encuentra en el prefab toonchicken
public class Enemigos : MonoBehaviour, IDamage
{
    public GameObject target;
    public GameObject target2;
    float distanceToTarget;
    float distanceToTarget2;
    public int daño = 10;
    private Animator animator;
    public int life = 15;

    public static int contador = 0;

    public bool shootByPlayer;

    NavMeshAgent agent;
    public int puntosQueDa = 1;
    public GameObject PataMuslo;
    public GameObject moneda;
    Vector3 posMon;
    Vector3 posPat;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
  
    }
    // este codigo es el daño de la bala a las gallinas
    public void DoDamage(int vld, bool isPlayer)
    {//aqui se muestra cuanto daño le hemos hecho a la gallina y la funcion para restarle vida y que se destruya
        Debug.Log("Daño hecho = " + vld + " isPlayer = " + isPlayer);
        if(isPlayer == true)
        {
            life -= vld;
            if(life < 0)
            {
                Die();
            }
        }
    }
    //funcion de muerte de la gallina y se instancia la pata
    void Die()
    {
        
        posMon = new Vector3(transform.position.x, 2, transform.position.z);
        posPat = new Vector3(transform.position.x + 5, 1, transform.position.z);
        Destroy(gameObject);
        Instantiate(PataMuslo, posPat, transform.rotation);
        Instantiate(moneda, posMon, transform.rotation);
        
    }
    

    // este codigo es cuando la gallina colisiona con el jugador quite el daño dicho anteriormente
    private void OnCollisionEnter (Collision collision)
    {
        Debug.Log("Gallina golpea = ");
        collision.gameObject.GetComponent<VidaPlayer>().vida -= daño;
        collision.gameObject.GetComponent<VidaPlayer2>().vida -= daño;
    }
    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        target2 = GameObject.FindGameObjectWithTag("Player 2");

        distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
        distanceToTarget2 = Vector3.Distance(transform.position, target2.transform.position);
        //distance calcula la distancia entre la gallina y nosotros

        if (distanceToTarget < distanceToTarget2)
        {
            //el posNoRot es para que las gallinas no giren todo su cuerpo hacia nosotros
            Vector3 posNoRot = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
            transform.LookAt(posNoRot); //para que la gallina nos mire
            agent.SetDestination(target.transform.position); //para que la gallina nos persiga
        }

        else
        {
            Vector3 posNoRot2 = new Vector3(target2.transform.position.x, transform.position.y, target2.transform.position.z);
            transform.LookAt(posNoRot2);
            agent.SetDestination(target2.transform.position);
        }

        if(GetComponent<VidaPlayer>().vida == 0)
        {
            Vector3 posNoRot2 = new Vector3(target2.transform.position.x, transform.position.y, target2.transform.position.z);
            transform.LookAt(posNoRot2);
            agent.SetDestination(target2.transform.position);
        }

        if(GetComponent<VidaPlayer2>().vida == 0)
        {
            //el posNoRot es para que las gallinas no giren todo su cuerpo hacia nosotros
            Vector3 posNoRot = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
            transform.LookAt(posNoRot); //para que la gallina nos mire
            agent.SetDestination(target.transform.position); //para que la gallina nos persiga
        }

        if (transform.position.y < -10)
        {
            Destroy(gameObject); //se destruye la gallina si se cae 
        }

    }

    

    
}
