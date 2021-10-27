using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//este script se encuentra en el GameObject de PoolingManager
public class ObjectPooling : MonoBehaviour
{
    struct BulletInfo// aca se define el prefab de las balas que se utiliza y que script es el que usa la bala
    {
        public GameObject prefab;
        public Bullet scriptBullet;
    }
    public static ObjectPooling instance;
    public GameObject bulletPrefab;
    public int bulletAmount = 5;

    private List<BulletInfo> bullets;
    
    void Awake()
    {
        //Este codigo nos da una lista de 5 balas para que no se creen extras y se ocupe mucho espacio en el juego
        instance = this;
        bullets = new List<BulletInfo>(bulletAmount);
        for(int i = 0; i<bulletAmount; i++)
        {
            BulletInfo BPrefab;
            BPrefab.prefab = Instantiate(bulletPrefab);
            BPrefab.prefab.transform.SetParent(transform);
            BPrefab.prefab.SetActive(false);
            BPrefab.scriptBullet = BPrefab.prefab.GetComponent<Bullet>();
            bullets.Add(BPrefab);        
        }
    }

    public GameObject GetBullet(bool isPlayer)//esto define si el disparo lo realizo un jugador o un enemigo
    {
        int totalBullets = bullets.Count;
        for(int i=0; i<totalBullets; i++)
        {
            if(!bullets[i].prefab.activeInHierarchy)//Define si la bala la dispara un jugador o enemigo
            {
                bullets[i].prefab.SetActive(true);
                bullets[i].scriptBullet.shootByPlayer = isPlayer;
                return bullets[i].prefab;
            }
        }
        // Esto crea una nueva bala si ya se lleno la lista de las 5 balas
        BulletInfo BPrefab;
        BPrefab.prefab = Instantiate(bulletPrefab);
        BPrefab.prefab.transform.SetParent(transform);
        BPrefab.prefab.SetActive(true);
        BPrefab.scriptBullet = BPrefab.prefab.GetComponent<Bullet>();
        BPrefab.scriptBullet.shootByPlayer = isPlayer;
        bullets.Add(BPrefab);

        return BPrefab.prefab;
    }
}
