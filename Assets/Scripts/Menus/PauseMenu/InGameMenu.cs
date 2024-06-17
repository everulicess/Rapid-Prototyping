using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] GameObject PauseMenuPanel;
    [SerializeField] GameObject CreditsPanel;
    public void PauseMenuToggle()
    {
        PauseMenuPanel.SetActive(!PauseMenuPanel.activeInHierarchy);
        Time.timeScale = PauseMenuPanel.activeInHierarchy ? 0 : 1;
    }
    public void OnCreditsToggle()
    {
        CreditsPanel.SetActive(!CreditsPanel.activeInHierarchy);
    }
    // Start is called before the first frame update
    void Start()
    {
        
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

    }
}
