using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Star : MonoBehaviour
{
    [SerializeField] private int scoreValue = 10;
    [SerializeField] private float rotateSpeed = 10f;
    bool wasColected = false;
    ScoreKeeper scoreKeeper;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Update()
    {
        Rotation();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !wasColected)
        {
            wasColected = true;
            scoreKeeper.ModifyScore(scoreValue);
            Destroy(gameObject);
        }
    }

    void Rotation()
    {
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }
}