using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOxygen : Oxygen
{
    [SerializeField] private float startingTime;
    [SerializeField] public float currentTime = 0f;
    void Start()
    {
        currentTime = startingTime;
    }
    void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime < 0)
        {
            Destroy(this.gameObject);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Oxygen"))
        {
            currentTime += increaseOxygen;
        }
    }
}
