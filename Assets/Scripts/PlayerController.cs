using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int health= 100;
    PlayerCollisionManager playerCollisionManager;

    public Slider hpSlider;

    private void Awake()
    {
        playerCollisionManager = GetComponent<PlayerCollisionManager>();
    }
    private void OnEnable()
    {
        playerCollisionManager.onDamaged += OnDamaged;
    }

    private void OnDisable()
    {
        playerCollisionManager.onDamaged -= OnDamaged;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDamaged(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            health = 0;
            GameManager.SharedInstance.isGameStarted = false;
        }

        hpSlider.value = health;
    }
}
