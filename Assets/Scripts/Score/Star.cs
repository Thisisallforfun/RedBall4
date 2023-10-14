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
    AudioPlayer audioPlayer;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Update()
    {
        Rotation();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !wasColected)
        {
            audioPlayer.GetInstance().PlayStarClip();
            wasColected = true;
            scoreKeeper.GetInstance().ModifyScore(scoreValue);
            Destroy(gameObject);
        }
    }

    void Rotation()
    {
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }
}