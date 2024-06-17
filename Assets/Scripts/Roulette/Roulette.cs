using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using EasyUI.PickerWheelUI;
using TMPro;

public class Roulette : MonoBehaviour
{
    [SerializeField] Button uiSpinButton;
    [SerializeField] TextMeshProUGUI uiSpinButtonText;
    [SerializeField] PickerWheel wheel;
    Minigames minigameToLoad;
    void Start()
    {
        uiSpinButton.onClick.AddListener(() =>
        {
            uiSpinButton.interactable = false;
            uiSpinButtonText.text = "Spinning";

            wheel.OnSpinStart(() =>
            {
                Debug.Log($"Sppin started...");
            });
            wheel.OnSpinEnd(WheelPiece =>
            {
                StartCoroutine(OnSpinEnd());
                minigameToLoad = WheelPiece.minigameScene;
                uiSpinButton.interactable = true;
                uiSpinButtonText.text = "Spin";
            });
            wheel.Spin();
        });
    }

   IEnumerator OnSpinEnd()
    {
        Debug.Log($"Spin End:");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadSceneAsync(minigameToLoad.ToString(), LoadSceneMode.Single);
    }
}
