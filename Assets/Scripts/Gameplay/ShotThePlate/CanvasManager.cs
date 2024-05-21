using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] GameObject[] buttons;
    [SerializeField] GameObject SelectPanel;

    [SerializeField] GameObject HintPanel;
    public void OnSelectClicked()
    {
        if (!PlateGameplayManager.instance.hasSelected)
            return;
        SelectPanel.SetActive(false);
        foreach (GameObject item in buttons)
        {
            item.SetActive(false);
        }
    }
    public void OnHintDoneClicked()
    {
        HintPanel.SetActive(false);
        SelectPanel.SetActive(true);
    }
}
