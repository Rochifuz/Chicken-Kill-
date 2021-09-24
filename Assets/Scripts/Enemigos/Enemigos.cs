using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigos : MonoBehaviour
{
    public GameObject target;
    float distanceToTarget;

    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");


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
