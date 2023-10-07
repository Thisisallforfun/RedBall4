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
        if (other.gameObject.tag != "Player")
        {
            moveSpeed = -moveSpeed;
            FlipEnemyFacing();
        }
    }

    private void FlipEnemyFacing()
    {
        transform.localScale = new Vector3(1f, -Mathf.Sign(rb.velocity.y), 0f);
    }
}