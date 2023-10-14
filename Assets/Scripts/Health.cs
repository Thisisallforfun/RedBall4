using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private bool isPlayer;
    [SerializeField] private int health = 5;
    [SerializeField] private int score = 10;
    [SerializeField] private float hurtForce = 5f;
    ScoreKeeper scoreKeeper;
    Player player;
    Animator anim;
    AudioPlayer audioPlayer;
    SpriteRenderer sprite;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        player = FindObjectOfType<Player>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
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
        // Events happen when enemy is dead
        if (!isPlayer)
        {
            audioPlayer.GetInstance().PlayBoomClip();
            anim.SetTrigger("isDead");
            scoreKeeper.ModifyScore(score);
            StartCoroutine(EnemyDead());
        }
        // Events happen when player is dead
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

    // Enmy is damaged by player
    void InteractWithPlayer(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (player.isFalling)
            {
                TakeDamage();
            }
        }
    }

    // Player touch Enemy
    void InteractWithEnemy(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (player.isFalling)
            {
                player.rb.velocity += new Vector2(0f, player.jumpSpeed);
            }
            else
            {
                float posX = player.transform.position.x;
                float posY = player.transform.position.y;

                // Player is at the left of the enemy
                if (posX < other.gameObject.transform.position.x)
                {
                    player.transform.position = new Vector2(posX - hurtForce, posY);
                }
                // Player is at the right of the enemy
                else if (posX >= other.gameObject.transform.position.x)
                {
                    player.transform.position = new Vector2(posX + hurtForce, posY);
                }

                // Play audio clip
                audioPlayer.GetInstance().PlayHurtClip();

                // Set Animation
                StartCoroutine(SetAnimation());

                // Damage
                TakeDamage();
            }
        }
    }

    IEnumerator SetAnimation()
    {
        anim.SetBool("isHurting", true);

        yield return new WaitForSeconds(0.5f);
        anim.SetBool("isHurting", false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Water")
        {
            audioPlayer.GetInstance().PlayDrownClip();
            player.rb.velocity = new Vector2(0, 0);
            player.isAlive = false;
            sprite.color = new Color(0.454902f, 0.8509804f, 1);
            anim.SetTrigger("sinked");
        }
    }

}
