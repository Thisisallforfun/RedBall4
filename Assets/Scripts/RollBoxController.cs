using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollBoxController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float moveSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(moveSpeed, 0f);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            moveSpeed = -moveSpeed;
            FlipEnemyFacing();
        }
    }

    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     if (other.gameObject.CompareTag("Wood Box"))
    //     {
    //         moveSpeed = -moveSpeed;
    //         FlipEnemyFacing();
    //     }
    // }

    private void FlipEnemyFacing()
    {
        transform.localScale = new Vector3(1f, -Mathf.Sign(rb.velocity.x), 0f);
    }
}