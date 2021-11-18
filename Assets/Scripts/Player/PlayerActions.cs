using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
//Este script se encientra en player
public class PlayerActions : MonoBehaviour, IDamage2
{

    public Transform posGun; //Posicion del arma
    public Transform cam; //Posicion de camara
    public GameObject bulletPrefab;//Llama al prefab de la bala
    public LayerMask ignoreLayer;//Ignorar la colision con el jugador
    RaycastHit hit;//Lanza un tiro desde, hacia(direccion) con un maximo de distancia 
    public float shotRateGlock = 1.5f;//Tiempo de disparo de Glock
    public float shotRateUzi = 0.8f;//Tiempo de disparo de Uzi
    public float shotRateAk = 0.3f;//Tiempo de disparo de AK
    public float shotRateTime = 0;//Tiempo general de disparo
    public int numeroArma;//Contiene el numero de arma que tiene el player
    public int contador = 0;
    public Text recordText;

    PhotonView view;

    GUIStyle smallFont;
    GUIStyle largeFont;

    void Start()
    {
        smallFont = new GUIStyle();
        largeFont = new GUIStyle();

        smallFont.fontSize = 10;
        largeFont.fontSize = 32;

        view = GetComponent<PhotonView>();
    }






    private void Update()
    {
        if (view.IsMine)
        {



            Debug.Log("La cantidad de puntos son: " + contador);
            numeroArma = GetComponent<AgarrarArmas>().numeroArmaActiva;//Trae el numero de arma que esta activa
            Debug.Log(numeroArma);//Te devuelve en la consola el numero de arma activa
            Debug.DrawRay(cam.position, cam.forward * 100f, Color.red);// traza una linea de la camara
            Debug.DrawRay(posGun.position, cam.forward * 100f, Color.blue);//traza una linea desde el arma


            //Funciones en base que arma esta activa

            if (numeroArma == 1)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    //le da una tiempo de recuperacion para volver a disparar
                    if (Time.time > shotRateTime)
                    {
                        shotRateTime = Time.time + shotRateAk;

                        Vector3 direction = cam.TransformDirection(new Vector3(Random.Range(-0.05f, 0.05f), Random.Range(-0.05f, 0.05f), 1));
                        Debug.DrawRay(cam.position, direction * 100f, Color.green, 5f);//muestra una linea de la bala

                        //GameObject bulletObj = Instantiate(bulletPrefab);
                        GameObject bulletObj = ObjectPooling.instance.GetBullet(true);//instancia la bala al hacer click y dice que es del jugador

                        bulletObj.transform.position = posGun.position;// la bala sale desde el arma
                        if (Physics.Raycast(cam.position, direction, out hit, Mathf.Infinity, ~ignoreLayer))//le da la direccion a la bala y a su linea
                        {
                            bulletObj.transform.LookAt(hit.point);//La da la direccion a la bala de donde nosotros estamos mirando
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
            else if (numeroArma == 2)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (Time.time > shotRateTime)
                    {

                        shotRateTime = Time.time + shotRateUzi;

                        Vector3 direction = cam.TransformDirection(new Vector3(Random.Range(-0.05f, 0.05f), Random.Range(-0.05f, 0.05f), 1));
                        Debug.DrawRay(cam.position, direction * 100f, Color.green, 5f);//muestra una linea de la bala

                        //GameObject bulletObj = Instantiate(bulletPrefab);
                        GameObject bulletObj = ObjectPooling.instance.GetBullet(true);//instancia la bala al hacer click y dice que es del jugador

                        bulletObj.transform.position = posGun.position;// la bala sale desde el arma
                        if (Physics.Raycast(cam.position, direction, out hit, Mathf.Infinity, ~ignoreLayer))//le da la direccion a la bala y a su linea
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
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    //le da una tiempo de recuperacion para volver a disparar
                    if (Time.time > shotRateTime)
                    {
                        shotRateTime = Time.time + shotRateGlock;

                        Vector3 direction = cam.TransformDirection(new Vector3(Random.Range(-0.05f, 0.05f), Random.Range(-0.05f, 0.05f), 1));
                        Debug.DrawRay(cam.position, direction * 100f, Color.green, 5f);//muestra una linea de la bala

                        //GameObject bulletObj = Instantiate(bulletPrefab);
                        GameObject bulletObj = ObjectPooling.instance.GetBullet(true);//instancia la bala al hacer click y dice que es del jugador

                        bulletObj.transform.position = posGun.position;// la bala sale desde el arma
                        if (Physics.Raycast(cam.position, direction, out hit, Mathf.Infinity, ~ignoreLayer))//le da la direccion a la bala y a su linea
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
    }
    public void DoDamage2(int vld2, bool isPlayer2)
    {//daño que se recibe y por parte de quien
        Debug.Log("Recibi Daño = " + vld2 + "isPlayer = " +isPlayer2);
        if (isPlayer2 == false)//La bala que le pega no es un player, le quita daño en la vida
        {
            gameObject.GetComponent<VidaPlayer>().vida -= vld2;            
        }

    }

    public void incremento(int valor) //Funcion en la cual incrementa los puntos
    {
        contador += valor;
        if(contador >= MaximosPuntos()) //Si los puntos actuales son mayores al record, se envia los puntos actuales a la funcion guardar puntos.
        {
            recordText.text = "Record: " + contador.ToString(); 
            GuardarDatos(contador);
        }
    }

    private void OnGUI()
    {
        GUI.contentColor = Color.black;
        GUI.Label(new Rect(800, 10, 500, 500), "Puntaje Jugador: " + contador, largeFont);
       
        
    }

    public int MaximosPuntos() //El maximo de puntos se arranca en 0 
    {
        return PlayerPrefs.GetInt("Max Puntos", 0); //El player prefs almacena un valor
    }

    public void GuardarDatos(int puntosActual) // Aqui toma la cantidad de puntos actuales
    {
        PlayerPrefs.SetInt("Max Puntos", puntosActual); 
    }

}

