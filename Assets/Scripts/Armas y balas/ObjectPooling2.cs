using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//este script se encuentra en el GameObject de PoolingManager
public class ObjectPooling2 : MonoBehaviour
{
    struct BulletInfos// aca se define el prefab de las balas que se utiliza y que script es el que usa la bala
    {
        public GameObject prefab;
        public Bullet2 scriptBullet2;
    }
    public static ObjectPooling2 instance;
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
            BPrefab.prefab = Instantiate(bulletPrefab);
            BPrefab.prefab.transform.SetParent(transform);
            BPrefab.prefab.SetActive(false);
            BPrefab.scriptBullet2 = BPrefab.prefab.GetComponent<Bullet2>();
            bullets.Add(BPrefab);        
        }
    }

    public GameObject GetBullet2(bool isPlayer2)//esto define si el disparo lo realizo un jugador o un enemigo
    {
        int totalBullets = bullets.Count;
        for(int i=0; i<totalBullets; i++)
        {
            if(!bullets[i].prefab.activeInHierarchy)//Define si la bala la dispara un jugador o enemigo y si una bala se encuentra en false la pasa a true
            {
                bullets[i].prefab.SetActive(true);
                bullets[i].scriptBullet2.shootByPlayer2 = isPlayer2;
                return bullets[i].prefab;
            }
        }
        // Esto crea una nueva bala si ya se lleno la lista de las 5 balas
        BulletInfos BPrefab;
        BPrefab.prefab = Instantiate(bulletPrefab);
        BPrefab.prefab.transform.SetParent(transform);
        BPrefab.prefab.SetActive(true);
        BPrefab.scriptBullet2 = BPrefab.prefab.GetComponent<Bullet2>();
        BPrefab.scriptBullet2.shootByPlayer2 = isPlayer2;
        bullets.Add(BPrefab);

        return BPrefab.prefab;
    }
}

