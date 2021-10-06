using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PataMuslo : MonoBehaviour
{
    Rigidbody rbPataMuslo;
    // Start is called before the first frame update
    void Start()
    {
        rbPataMuslo = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        
       rbPataMuslo.AddForce(transform.forward, ForceMode.Impulse - 5);
    }
}
