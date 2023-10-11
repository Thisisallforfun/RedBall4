using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] float loadLevelDelay = 0.5f;
    AudioPlayer audioPlayer;

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(LoadNextLevel());
        }
    }

    IEnumerator LoadNextLevel()
    {
        audioPlayer.GetInstance().PlayFinishClip();

        yield return new WaitForSecondsRealtime(loadLevelDelay);

        int nextScenceIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextScenceIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextScenceIndex = 0;
            // Task: go to Win scence
        }
        // FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(nextScenceIndex);
    }
}
