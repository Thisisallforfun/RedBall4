using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI lifeText;
    [SerializeField] private TextMeshProUGUI hpText;

    ScoreKeeper scoreKeeper;
    public Health health;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }


    private void Update()
    {
        scoreText.text = scoreKeeper.GetScore().ToString("000");
        lifeText.text = $"Life: {health.GetLife()}";
        hpText.text = $"HP: {health.GetHealth()}";
    }
}
