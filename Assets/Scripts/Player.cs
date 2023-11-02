using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float maxSpeed = 20f;
    [SerializeField] private float speedUp = 0.5f;
    [SerializeField] private float speedDown = 0.5f;
    [SerializeField] public float jumpSpeed = 10f;
    public Rigidbody2D rb;
    [SerializeField] private Vector2 moveInput;
    CircleCollider2D bodyColl;
    public bool isFalling = false;
    AudioPlayer audioPlayer;
    private float defaultSpeed = 0f;
    public bool isAlive = true;
    Vector2 checkpointPos;

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bodyColl = GetComponent<CircleCollider2D>();
        defaultSpeed = moveSpeed;
        checkpointPos = transform.position;
    }

    private void Update()
    {
        Run();
        isFalling = rb.velocity.y < -0.01f;
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Run()
    {
        if (!isAlive) return;

        if (moveInput.x != 0)
        {
            moveSpeed += speedUp;
        }
        else
        {
            moveSpeed -= speedDown;
            if (moveSpeed <= 0)
            {
                moveSpeed = defaultSpeed;
            }
        }

        if (moveSpeed > maxSpeed)
        {
            moveSpeed = maxSpeed;
        }

        Vector2 playerVelocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);
        rb.velocity = playerVelocity;
    }

    void OnJump(InputValue value)
    {
        if (!isAlive) return;
        bool isStanding = bodyColl.IsTouchingLayers(LayerMask.GetMask("Ground", "Subplatform"));

        if (value.isPressed && isStanding)
        {
            audioPlayer.GetInstance().PlayJumpingClip();
            rb.velocity += new Vector2(0f, jumpSpeed);
        }
    }

    public IEnumerator Respawn(float duration)
    {
        rb.velocity = new Vector2(0f, 0f);
        transform.localScale = new Vector3(0f, 0f, 0f);
        yield return new WaitForSeconds(duration);

        transform.position = checkpointPos;
        transform.localScale = new Vector3(1, 1, 1);
    }

    public void UpdateCheckpoint(Vector2 pos)
    {
        checkpointPos = pos;
    }


}
