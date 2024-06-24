using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    int score = 0;
    [SerializeField] GameObject ScorePanel;
    [SerializeField] TextMeshProUGUI ScoreText;

    [Header("EndingScreen")]
    [SerializeField] GameObject EndScreen;
    [SerializeField] TextMeshProUGUI FinalScoreText;

    [Header("Abilities")]
    [SerializeField] GameObject ability1;
    [SerializeField] GameObject ability2;
    void Start()
    {
        instance = this;
        EventManager.AddListener<OnScoreUpdate>(UpdateScore);
        EventManager.AddListener<OnPlayerCollide>(HandleEndScreen);

        EventManager.AddListener<OnQuitGame>(QuitGame);
    }
    
    private void QuitGame(OnQuitGame evt)
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }
    private void HandleEndScreen(OnPlayerCollide evt)
    {
        ScorePanel.SetActive(false);
        EndScreen.SetActive(true);
        FinalScoreText.text = $"Your Score is: {score}";
    }
    private void OnDestroy()
    {
        EventManager.RemoveListener<OnScoreUpdate>(UpdateScore);
        EventManager.RemoveListener<OnPlayerCollide>(HandleEndScreen);
        EventManager.RemoveListener<OnQuitGame>(QuitGame);

    }
    private void UpdateScore(OnScoreUpdate evt)
    {
        score += evt.GoldIncrease;
        ScoreText.text = $"Coins: {score}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
