
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour, IEnemy, IPoolable
{
    public static Enemy SharedInstance = null;
    public float speed;

    private Transform player;
    private Rigidbody rb;
    private int attackCount;

    private void Awake()
    {
        SharedInstance = this;

        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (!GameManager.SharedInstance.isGameStarted)
        {
            return;
        }
        transform.LookAt(player);
        Vector3 direction = (player.position - transform.position).normalized;
        rb.AddForce(direction * speed, ForceMode.Acceleration);
    }

    public void Reset()
    {
        gameObject.SetActive(false);
        transform.position = Vector3.zero;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    public void ResetDelayed(float delay)
    {
        Invoke("Reset", delay);
    }

    private void OnTriggerEnter(Collider other)
    {
        attackCount++;
        if (other.CompareTag("Bullet"))
        {
            rb.AddForce(-transform.forward * 20, ForceMode.Impulse);
            
            if (attackCount == 2)
            {
                other.GetComponent<IPoolable>().Reset();
                Reset();
                attackCount = 0;
            }

            Debug.Log("Zombie dead");
        }
    }
}
