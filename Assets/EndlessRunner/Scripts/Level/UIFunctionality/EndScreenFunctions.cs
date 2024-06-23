using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenFunctions : MonoBehaviour
{
    public void OnMenuClicked()
    {
        SceneManager.LoadScene(0);
    }
    public void OnRestartClicked()
    {
        string game = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(game);
    }
}
