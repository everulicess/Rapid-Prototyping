using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] GameObject PauseMenuPanel;
    [SerializeField] GameObject CreditsPanel;
    public static InGameMenu Singleton;
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
    public void PauseMenuToggle()
    {
        PauseMenuPanel.SetActive(!PauseMenuPanel.activeInHierarchy);
        Time.timeScale = PauseMenuPanel.activeInHierarchy ? 0 : 1;
    }
    public void OnCreditsToggle()
    {
        CreditsPanel.SetActive(!CreditsPanel.activeInHierarchy);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenuToggle();
        }
    }

    public void OnQuitButton()
    {
        OnQuitGame evt = new();
        EventManager.Broadcast(evt);
    }
}
