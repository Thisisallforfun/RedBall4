using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    AudioPlayer audioPlayer;
    private bool hasPlayed = false;

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !hasPlayed)
        {
            audioPlayer.GetInstance().PlayCheckpoint();
            hasPlayed = true;
        }
    }
}
