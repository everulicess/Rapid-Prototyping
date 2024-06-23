using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponsData", menuName = "Weapons")]
public class ScrObj_WeaponData : ScriptableObject
{
    public Options weapon;
    [Header("Bullet Settings")]
    public GameObject bulletPrefab;
    [Header("Shooting Settings")]
    public int bulletsXShot;
    public bool isAutomatic;
    [Header("Magazine Settings")]
    public int magazineSize;
    public float reloadTime;
    [HideInInspector]public float reloadTimeXBullet
    {
        get
        {
            return reloadTime / (float)magazineSize;
        }
    }
}
