using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour
{
    public delegate void OnDamaged(int amount);
    public OnDamaged onDamaged;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {
            onDamaged(10);
            other.GetComponent<IPoolable>().Reset();
        }
    }


}
