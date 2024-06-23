using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralManager : MonoBehaviour
{
    public int Gold;
    public static GeneralManager Singleton;
    private void Awake()
    {
        if (Singleton != null && Singleton != this)
        {
            Destroy(this);
        }
        else
        {
            Singleton = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        EventManager.AddListener<OnShopBuy>(OnBuyShop);
        EventManager.AddListener<OnScoreUpdate>(UpdateScore);
        EventManager.AddListener<OnMiniGameFinished>(MinigameFinihsed);

        EventManager.AddListener<OnQuitGame>(QuitGame);

    }

    private void QuitGame(OnQuitGame obj)
    {
#if !UNITY_EDITOR
        Application.Quit();
#else
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    private void MinigameFinihsed(OnMiniGameFinished evt)
    {
        SceneManager.LoadScene(evt.Roulette.ToString());
    }
    private void UpdateScore(OnScoreUpdate evt)
    {
        Gold += evt.GoldIncrease;
    }
    private void OnDestroy()
    {
        EventManager.RemoveListener<OnShopBuy>(OnBuyShop);
        EventManager.RemoveListener<OnScoreUpdate>(UpdateScore);
        EventManager.RemoveListener<OnMiniGameFinished>(MinigameFinihsed);

        EventManager.RemoveListener<OnQuitGame>(QuitGame);

    }
    private void OnBuyShop(OnShopBuy evt)
    {
        Gold -= evt.Price;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
