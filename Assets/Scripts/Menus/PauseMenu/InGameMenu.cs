using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
    [SerializeField] GameObject PauseMenuPanel;
    public void PauseMenuToggle()
    {
        PauseMenuPanel.SetActive(!PauseMenuPanel.activeInHierarchy);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
