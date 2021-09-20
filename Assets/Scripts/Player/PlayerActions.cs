using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{

    public Transform posGun;
    public Transform cam;
    public GameObject bulletPrefab;

    private void Update()
    {
        Debug.DrawRay(cam.position, cam.forward * 100f, Color.red);
        Debug.DrawRay(posGun.position, cam.forward * 100f, Color.blue);

        if(Input.GetMouseButtonDown(0))
        {
            GameObject bulletObj = Instantiate(bulletPrefab);
            bulletObj.transform.position = posGun.position;
            Vector3 dir = cam.position + cam.forward * 10f;
            bulletObj.transform.LookAt(dir);
        }
    }

}

