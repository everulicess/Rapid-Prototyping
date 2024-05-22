using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public enum ChoiceScenes
{
    Setting_1,
    Setting_2,
    Setting_3,
}
public class GameManager2 : MonoBehaviour
{
    List<ChoiceScenes> ScenesList = new();
    // Start is called before the first frame update
    void Awake()
    {
        Events.OnSceneFiished += OnSceneFinished;
        foreach (ChoiceScenes item in Enum.GetValues(typeof(ChoiceScenes)))
        {
            ScenesList.Add(item);
        }
        DontDestroyOnLoad(this);
    }
    private void OnDestroy()
    {
        Events.OnSceneFiished -= OnSceneFinished;

    }
    private void OnSceneFinished(ChoiceScenes sceneDone)
    {
        if (ScenesList.Contains(sceneDone))
            ScenesList.Remove(sceneDone);

        SceneManager.LoadSceneAsync(nameof(MyScenes.Menu));
        foreach (ChoiceScenes item in ScenesList)
        {
            Debug.Log(item);

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
