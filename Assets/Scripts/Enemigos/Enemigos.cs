using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigos : MonoBehaviour, IDamage
{
    public GameObject target;
    float distanceToTarget;

    public int life = 15;

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
