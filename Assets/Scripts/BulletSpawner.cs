using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour//, IEnemy
{
   
    public GameObject bulletObject;
    public Transform bulletPivot;

    public float spawnInternal;
    private float timePassed;
    public int poolSize;

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject go = Instantiate(bulletObject, Vector3.zero, Quaternion.identity);
            go.transform.SetParent(bulletPivot);
        }
    }



    public GameObject GetAvailableBullet()
    {
        GameObject _bullet = null;

        foreach (Transform bullet in bulletPivot)
        {
            if (!bullet.gameObject.activeInHierarchy)
            {
                _bullet = bullet.gameObject;
            }
        }

        return _bullet;
    }

}
