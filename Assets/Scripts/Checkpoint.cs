using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    AudioPlayer audioPlayer;
    private bool hasPlayed = false;
    Player player;

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
        player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !hasPlayed)
        {
            audioPlayer.GetInstance().PlayCheckpoint();
            player.UpdateCheckpoint(transform.position);
            hasPlayed = true;
        }
    }
}
