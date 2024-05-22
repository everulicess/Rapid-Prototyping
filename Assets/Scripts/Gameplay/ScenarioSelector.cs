using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenarioSelector : MonoBehaviour
{
    public void GoToScenario()
    {
        SceneManager.LoadSceneAsync(nameof(ChoiceScenes.Setting_1));
    }
}
