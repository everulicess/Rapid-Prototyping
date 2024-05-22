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
    [SerializeField] GameObject RiflePrefab;
    [SerializeField] GameObject MachinegunPrefab;
    [SerializeField] GameObject SniperPrefab;

    int highScore = 0;
    private void Awake()
    {
        instance = this;
        Events.OnPlateDestroyed += IncreaeScore;
        Events.OnWeaponSelected += SetSelectedWeapon;
    }
    private void OnDestroy()
    {
        Events.OnPlateDestroyed -= IncreaeScore;
        Events.OnWeaponSelected -= SetSelectedWeapon;
    }
    void IncreaeScore(bool isDestroyed)
    {
        if (!isDestroyed)
            return;
        highScore++;
        Debug.Log($"your highscore is: {highScore}");
        if (highScore == 3&&SceneManager.GetActiveScene().name!= nameof(ChoiceScenes.Setting_1))
        {
            Events.OnSceneFiished(ChoiceScenes.Setting_1);
        }
    }

    void SetSelectedWeapon(Options selected)
    {
        chosenWeapon = selected;
        Debug.Log($"your weapon is: {chosenWeapon}");

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
