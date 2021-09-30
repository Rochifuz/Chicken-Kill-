using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigos : MonoBehaviour, IDamage
{
    public GameObject target;
    float distanceToTarget;
    public int daño = 10;

    public int life = 15;

    public bool shootByPlayer;

    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");


    }

    public void DoDamage(int vld, bool isPlayer)
    {
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

    void Die()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter (Collision collision)
    {
        Debug.Log("Gallina golpea = ");
        collision.gameObject.GetComponent<VidaPlayer>().vida -= daño;              
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 posNoRot = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
        transform.LookAt(posNoRot);
        distanceToTarget = Vector3.Distance(transform.position, target.transform.position);

        agent.SetDestination(target.transform.position);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    
}
