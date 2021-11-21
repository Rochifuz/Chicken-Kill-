using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ProbarEnemigo : MonoBehaviour
{
	// Start is called before the first frame update
	public Transform Player1;
	public Transform Player2;

	public float Distancia1;
	public float Distancia2;

	public NavMeshAgent nav;

	public int SP;


	void Update()
	{

		Distancia1 = Vector3.Distance(transform.position, Player1.position);
		Distancia2 = Vector3.Distance(transform.position, Player2.position);

		if (Distancia1 < Distancia2)
		{
			SP = 1;
		}

		if (Distancia2 < Distancia1)
		{
			SP = 2;
		}

		if (SP == 1)
		{
			nav.destination = Player1.position;
		}

		if (SP == 2)
		{
			nav.destination = Player2.position;
		}
	}

}
