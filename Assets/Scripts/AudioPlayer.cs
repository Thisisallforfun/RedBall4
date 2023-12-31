using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("PLAYER")]
    [Header("Jumping")]
    [SerializeField] AudioClip jumpingClip1;
    [SerializeField] AudioClip jumpingClip2;
    [SerializeField] AudioClip jumpingClip3;
    [SerializeField][Range(0f, 1f)] float jumpVolume = 1f;
    List<AudioClip> jumpClips;

    [Header("Hurt")]
    [SerializeField] AudioClip hurtClip;
    [SerializeField][Range(0f, 1f)] float hurtVolume = 1f;

    [Header("Drown")]
    [SerializeField] AudioClip drownClip;
    [SerializeField][Range(0f, 1f)] float drownVolume = 1f;

    [Header("Angel")]
    [SerializeField] AudioClip angelClip;
    [SerializeField][Range(0f, 1f)] float angelVolume = 1f;

    [Header("ENEMY")]
    [Header("Box Boom")]
    [SerializeField] AudioClip boxBoomClip;
    [SerializeField][Range(0f, 1f)] float boxBoomVolume = 1f;

    [Header("SYSTEM")]
    [Header("Finish Level")]
    [SerializeField] AudioClip finishClip;
    [SerializeField][Range(0f, 1f)] float finishVolume = 1f;

    [Header("Pick up")]
    [SerializeField] AudioClip starClip;
    [SerializeField][Range(0f, 1f)] float starVolume = 1f;

    [Header("Check point")]
    [SerializeField] AudioClip checkpointClip;
    [SerializeField][Range(0f, 1f)] float checkpointVolume = 1f;



    static AudioPlayer instance;

    public AudioPlayer GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        ManageSingleton();

        jumpClips = new List<AudioClip>();
        jumpClips.Add(jumpingClip1);
        jumpClips.Add(jumpingClip2);
        jumpClips.Add(jumpingClip3);
    }

    void ManageSingleton()
    {
        if (instance != null)
        {
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            Vector3 camPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, camPos, volume);
        }
    }

    public void PlayJumpingClip()
    {
        int i = Random.Range(0, jumpClips.Count - 1);
        PlayClip(jumpClips[i], jumpVolume);
    }

    public void PlayHurtClip()
    {
        PlayClip(hurtClip, hurtVolume);
    }

    public void PlayFinishClip()
    {
        PlayClip(finishClip, finishVolume);
    }

    public void PlayStarClip()
    {
        PlayClip(starClip, starVolume);
    }

    public void PlayBoomClip()
    {
        PlayClip(boxBoomClip, boxBoomVolume);
    }

    public void PlayDrownClip()
    {
        PlayClip(drownClip, drownVolume);
    }

    public void PlayCheckpoint()
    {
        PlayClip(checkpointClip, checkpointVolume);
    }

    public void PlayAngelClip()
    {
        PlayClip(angelClip, angelVolume);
    }
}
