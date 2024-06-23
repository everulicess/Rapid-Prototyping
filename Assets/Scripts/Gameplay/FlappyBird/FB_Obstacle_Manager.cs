using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FB_Obstacle_Manager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ScoreText;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.AddListener<OnObstacleArrived>(MoveObstacle);
        EventManager.AddListener<OnScoreUpdate>(UpdateScore);

        ScoreText.text = $"Score: {score}";
    }
    private void UpdateScore(OnScoreUpdate evt)
    {
        score += evt.GoldIncrease;
        ScoreText.text = $"Score: {score}";

    }

    private void OnDestroy()
    {
        EventManager.RemoveListener<OnObstacleArrived>(MoveObstacle);
        EventManager.RemoveListener<OnScoreUpdate>(UpdateScore);
    }
    private void MoveObstacle(OnObstacleArrived evt)
    {
        float newYPos = UnityEngine.Random.Range(-5, 5);
        Vector3 newPos = new(20, newYPos, evt.InitialPosition.z);
        evt.Obstacle.transform.position = newPos;
    }
}
