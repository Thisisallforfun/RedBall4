using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rollbox : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float speed = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(speed, 0f);
    }
}
