using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPoolable
{
    private Rigidbody rb;
    private float timePassed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {

    }

    private void Update()
    {
        if (timePassed >= 1)
        {
            Reset();
            timePassed = 0;
        }

        else
        {
            timePassed += Time.deltaTime;
        }
    }
    public void Reset()
    {       
        gameObject.SetActive(false);
        transform.position = Vector3.zero;
        rb.velocity = Vector3.zero;
    }


}
