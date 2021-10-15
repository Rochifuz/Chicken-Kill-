using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour, IDamage
{

    public Transform posGun;
    public Transform cam;
    public GameObject bulletPrefab;
    public LayerMask ignoreLayer;
    RaycastHit hit;
    public float shotRate = 0.5f;
    public float shotRate1 = 2.1f;
    public float shotRateTime = 0;
    public int numeroArma; 

    
    private void Start(){
        
    }



    private void Update()
    {
        numeroArma = GetComponent<AgarrarArmas>().numeroArmaActiva;
        Debug.Log(numeroArma);
        Debug.DrawRay(cam.position, cam.forward * 100f, Color.red);// traza una linea de la camara
        Debug.DrawRay(posGun.position, cam.forward * 100f, Color.blue);//traza una linea desde el arma

        if(numeroArma == 1){
        if(Input.GetMouseButtonDown(0))
        {
            //le da una tiempo de recuperacion para volver a disparar
            if(Time.time > shotRateTime)
            {
                shotRateTime = Time.time + shotRate;
            
            Vector3 direction = cam.TransformDirection(new Vector3(Random.Range(-0.05f, 0.05f), Random.Range(-0.05f, 0.05f), 1));
            Debug.DrawRay(cam.position, direction * 100f, Color.green, 5f);//muestra una linea de la bala

            //GameObject bulletObj = Instantiate(bulletPrefab);
            GameObject bulletObj = ObjectPooling.instance.GetBullet(true);//instancia la bala al hacer click y dice que es del jugador

            bulletObj.transform.position = posGun.position;// la bala sale desde el arma
            if(Physics.Raycast(cam.position, direction, out hit, Mathf.Infinity, ~ignoreLayer))//le da la direccion a la bala y a su linea
            {
                bulletObj.transform.LookAt(hit.point);
            }
            else
            {
                //Vector3 dir = cam.position + cam.forward * 10f;
                Vector3 dir = cam.position + direction * 10f;
                bulletObj.transform.LookAt(dir);
            }
            }
        }
        }else if(numeroArma ==2){
        if(Input.GetMouseButtonDown(0))
        {
            if(Time.time > shotRateTime)
            {
            
            shotRateTime = Time.time + shotRate1;
            
            Vector3 direction = cam.TransformDirection(new Vector3(Random.Range(-0.05f, 0.05f), Random.Range(-0.05f, 0.05f), 1));
            Debug.DrawRay(cam.position, direction * 100f, Color.green, 5f);//muestra una linea de la bala

            //GameObject bulletObj = Instantiate(bulletPrefab);
            GameObject bulletObj = ObjectPooling.instance.GetBullet(true);//instancia la bala al hacer click y dice que es del jugador

            bulletObj.transform.position = posGun.position;// la bala sale desde el arma
            if(Physics.Raycast(cam.position, direction, out hit, Mathf.Infinity, ~ignoreLayer))//le da la direccion a la bala y a su linea
            {
                bulletObj.transform.LookAt(hit.point);
            }
            else
            {
                //Vector3 dir = cam.position + cam.forward * 10f;
                Vector3 dir = cam.position + direction * 10f;
                bulletObj.transform.LookAt(dir);
            }
            
        }}   
        }else{
         if(Input.GetMouseButtonDown(0))
        {
            //le da una tiempo de recuperacion para volver a disparar
            if(Time.time > shotRateTime)
            {
                shotRateTime = Time.time + shotRate;
            
            Vector3 direction = cam.TransformDirection(new Vector3(Random.Range(-0.05f, 0.05f), Random.Range(-0.05f, 0.05f), 1));
            Debug.DrawRay(cam.position, direction * 100f, Color.green, 5f);//muestra una linea de la bala

            //GameObject bulletObj = Instantiate(bulletPrefab);
            GameObject bulletObj = ObjectPooling.instance.GetBullet(true);//instancia la bala al hacer click y dice que es del jugador

            bulletObj.transform.position = posGun.position;// la bala sale desde el arma
            if(Physics.Raycast(cam.position, direction, out hit, Mathf.Infinity, ~ignoreLayer))//le da la direccion a la bala y a su linea
            {
                bulletObj.transform.LookAt(hit.point);
            }
            else
            {
                //Vector3 dir = cam.position + cam.forward * 10f;
                Vector3 dir = cam.position + direction * 10f;
                bulletObj.transform.LookAt(dir);
            }
            }
        }   
        }
    }
    public void DoDamage(int vld, bool isPlayer)
    {//daño que se recibe y por parte de quien
        Debug.Log("Recibi Daño = " + vld + "isPlayer = " +isPlayer);
    }
}

