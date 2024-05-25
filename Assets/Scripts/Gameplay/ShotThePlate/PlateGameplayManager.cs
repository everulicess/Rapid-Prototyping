using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Options
{
    Rifle,
    Machinegun,
    Sniper
}
public class PlateGameplayManager : MonoBehaviour
{
    public static PlateGameplayManager instance;
    public bool hasSelected;
    Options chosenWeapon { get; set; }

    [SerializeField] Transform weaponPosition;

    public static GameObject RiflePrefab;
    public GameObject RiflePrefab_Inspector;
    public static GameObject MachinegunPrefab;
    public GameObject MachinegunPrefab_Inspector;
    public static GameObject SniperPrefab;
    public GameObject SniperPrefab_Inspector;

    int highScore = 0;
    private void Awake()
    {
        RiflePrefab = RiflePrefab_Inspector;
        MachinegunPrefab = MachinegunPrefab_Inspector;
        SniperPrefab = SniperPrefab_Inspector;
        instance = this;
        EventManager.AddListener<OnPlateBrokenEvent>(IncreaeScore);
        EventManager.AddListener<OnWeaponSelectedEvent>(SetSelectedWeapon);
    }
    private void OnDestroy()
    {
        EventManager.RemoveListener<OnPlateBrokenEvent>(IncreaeScore);
        EventManager.RemoveListener<OnWeaponSelectedEvent>(SetSelectedWeapon);

    }
    void IncreaeScore(OnPlateBrokenEvent evt)
    {

        highScore += evt.amountToIncrease;
        Debug.Log($"your highscore is: {highScore}");
        if (highScore >= 3 /*&& SceneManager.GetActiveScene().name!= nameof(ChoiceScenes.Setting_1)*/)
        {
            OnSceneFinished _evt = new();
            _evt.finishedScene = ChoiceScenes.Setting_1;
            EventManager.Broadcast(_evt);
        }
    }

    void SetSelectedWeapon(OnWeaponSelectedEvent evt)
    {
        chosenWeapon = evt.selectedWeapon;
        Debug.Log($"your weapon is: {chosenWeapon}");
        Instantiate(evt.WeaponPrefab, weaponPosition);

    }
    public GameObject SpawnWeapon()
    {
        return chosenWeapon switch
        {
            Options.Rifle => RiflePrefab,
            Options.Machinegun => MachinegunPrefab,
            Options.Sniper => SniperPrefab,
            _ => RiflePrefab,
        };
    }
   

}
