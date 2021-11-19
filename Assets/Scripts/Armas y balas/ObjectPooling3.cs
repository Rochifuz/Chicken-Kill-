using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
//este script se encuentra en el GameObject de PoolingManager
public class ObjectPooling3 : MonoBehaviourPun
{
    struct BulletInfos// aca se define el prefab de las balas que se utiliza y que script es el que usa la bala
    {
        public GameObject prefab;
        public Bullet3 scriptBullet3;
    }
    public static ObjectPooling3 instance;
    public GameObject bulletPrefab;
    public int bulletAmount = 5;

    private List<BulletInfos> bullets;
    
    void Awake()
    {
        //Este codigo nos da una lista de 5 balas para que no se creen extras y se ocupe mucho espacio en el juego
        instance = this;
        bullets = new List<BulletInfos>(bulletAmount);
        for(int i = 0; i<bulletAmount; i++)
        {
            BulletInfos BPrefab;
            BPrefab.prefab = PhotonNetwork.Instantiate(bulletPrefab.name, transform.position, Quaternion.identity);
            BPrefab.prefab.transform.SetParent(transform);
            BPrefab.prefab.SetActive(false);
            BPrefab.scriptBullet3 = BPrefab.prefab.GetComponent<Bullet3>();
            bullets.Add(BPrefab);        
        }
    }

    public GameObject GetBullet3(bool isPlayer2)//esto define si el disparo lo realizo un jugador o un enemigo
    {
        int totalBullets = bullets.Count;
        for(int i=0; i<totalBullets; i++)
        {
            if(!bullets[i].prefab.activeInHierarchy)//Define si la bala la dispara un jugador o enemigo y si una bala se encuentra en false la pasa a true
            {
                bullets[i].prefab.SetActive(true);
                bullets[i].scriptBullet3.shootByPlayer2 = isPlayer2;
                return bullets[i].prefab;
            }
        }
        // Esto crea una nueva bala si ya se lleno la lista de las 5 balas
        BulletInfos BPrefab;
        BPrefab.prefab = PhotonNetwork.Instantiate(bulletPrefab.name, transform.position, Quaternion.identity);
        BPrefab.prefab.transform.SetParent(transform);
        BPrefab.prefab.SetActive(true);
        BPrefab.scriptBullet3 = BPrefab.prefab.GetComponent<Bullet3>();
        BPrefab.scriptBullet3.shootByPlayer2 = isPlayer2;
        bullets.Add(BPrefab);

        return BPrefab.prefab;
    }
}


