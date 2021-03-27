using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trapdoors : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float startingTime;
    [SerializeField] private float currentTime=0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
        }
        if (currentTime < 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentTime = startingTime;
    }

}
