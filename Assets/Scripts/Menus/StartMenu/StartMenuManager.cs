using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum MyScenes
{
    Menu,
    Count,
    Roulette
}

public class StartMenuManager : MonoBehaviour
{
    [SerializeField] GameObject CreditsPanel;
    [SerializeField] GameObject OptionsPanel;

    [SerializeField] MyScenes sceneToLoad;

    private void Start()
    {
        HideAllPanels();
    }
    public void HideAllPanels()
    {
        CreditsPanel.SetActive(false);
        OptionsPanel.SetActive(false);
    }

    //CREDITS
    public void CreditsPanelToggle()
    {
        CreditsPanel.SetActive(!CreditsPanel.activeInHierarchy);
    }

    //OPTIONS
    public void OptionsPanelToggle()
    {
        OptionsPanel.SetActive(!OptionsPanel.activeInHierarchy);
    }

    public void OnVolumeChanged()
    {

    }

    //PLAY
    public void OnPlayClicked()
    {
        SceneManager.LoadSceneAsync(sceneToLoad.ToString());
    }

    //QUIT
    public void OnQuitClicked()
    {
        Application.Quit();
    }
}
