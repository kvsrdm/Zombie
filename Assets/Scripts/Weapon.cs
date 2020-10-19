using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Weapon : MonoBehaviour
{
    public Transform spawnPosition;
    public GameObject bullet;
    public GameObject bomb;
    private bool isShooting;
    private BulletSpawner bulletSpawner;
    private float timePassed;
    public float shootInterval = 0.5f;
    public float bulletForce;
    public float bombForce;

    private void Awake()
    {
        bulletSpawner = GetComponent<BulletSpawner>();

    }
    public void OnPointerDown()
    {
        isShooting = true;
    }
    public void OnPointerUp()
    {
        isShooting = false;
    }

    void Shoot()
    {
        GameObject bullet = bulletSpawner.GetAvailableBullet();
        bullet.transform.position = spawnPosition.position;
        bullet.SetActive(true);

        Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
        // Vector3 direction = (spawnPosition.position - transform.position).normalized;
        bulletRB.AddForce(-spawnPosition.forward * bulletForce);

    }

    void Update()
    {
        Debug.Log(isShooting);
        if (!GameManager.SharedInstance.isGameStarted)
        {
            return;
        }

        if (isShooting)
        {
            if (timePassed >= shootInterval)
            {
                Shoot();
                timePassed = 0;
            }
            else
            {
                timePassed += Time.deltaTime;

            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnPointerDown();

        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            OnPointerUp();
        }

    }

    public void ThrowBomb()
    {
        bomb.transform.position = spawnPosition.position;
        
        foreach (Transform child in bomb.transform)
        {
            child.localPosition = Vector3.zero;
        }
        bomb.SetActive(true);
        bomb.GetComponentInChildren<Rigidbody>().AddForce(-spawnPosition.forward * bombForce, ForceMode.Impulse);
        bomb.GetComponentInChildren<Bomb>().Explode();
    }
}
