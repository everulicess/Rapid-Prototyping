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
        EventManager.AddListener<OnSceneFinished>(OnSceneFinished);
        foreach (ChoiceScenes item in Enum.GetValues(typeof(ChoiceScenes)))
        {
            ScenesList.Add(item);
        }
        DontDestroyOnLoad(this);
    }
    private void OnDestroy()
    {
        EventManager.RemoveListener<OnSceneFinished>(OnSceneFinished);
    }
    private void OnSceneFinished(OnSceneFinished evt)
    {
        if (ScenesList.Contains(evt.finishedScene))
            ScenesList.Remove(evt.finishedScene);

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
