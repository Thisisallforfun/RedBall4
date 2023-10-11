using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Jumping")]
    [SerializeField] AudioClip jumpingClip;
    [SerializeField][Range(0f, 1f)] float jumpVolume = 1f;


    [Header("Hurt")]
    [SerializeField] AudioClip hurtClip;
    [SerializeField][Range(0f, 1f)] float hurtVolume = 1f;

    [Header("Finish Level")]
    [SerializeField] AudioClip finishClip;
    [SerializeField][Range(0f, 1f)] float finishVolume = 1f;


    [Header("Pick up")]
    [SerializeField] AudioClip starClip;
    [SerializeField][Range(0f, 1f)] float starVolume = 1f;

    static AudioPlayer instance;

    public AudioPlayer GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        ManageSingleton();
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
        PlayClip(jumpingClip, jumpVolume);
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
}
