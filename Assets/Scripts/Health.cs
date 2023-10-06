using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private bool isPlayer;
    [SerializeField] private int health = 5;
    [SerializeField] private int score = 10;
    ScoreKeeper scoreKeeper;
    Player player;
    Animator anim;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        player = FindObjectOfType<Player>();
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void TakeDamage()
    {
        health--;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (!isPlayer)
        {
            anim.SetBool("isDestroy", true);
            scoreKeeper.ModifyScore(score);
            StartCoroutine(EnemyDead());
        }
        else
        {
            Destroy(gameObject);
        }
    }

    IEnumerator EnemyDead()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!isPlayer)
        {
            InteractWithPlayer(other);
        }
        else
        {
            InteractWithEnemy(other);
        }
    }

    void InteractWithPlayer(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (player.rb.velocity.y < 0f)
            {
                TakeDamage();
            }
        }
    }

    void InteractWithEnemy(Collision2D other)
    {
        return;
    }
}
