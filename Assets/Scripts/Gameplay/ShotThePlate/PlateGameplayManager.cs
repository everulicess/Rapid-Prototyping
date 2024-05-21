using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    private void Awake()
    {
        instance = this;
    }

    public void SetSelectedWeapon(Options selected)
    {
        chosenWeapon = selected;
        Debug.Log($"{nameof(selected)}");
    }

}
