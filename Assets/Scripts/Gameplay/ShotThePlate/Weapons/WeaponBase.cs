using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    public ScrObj_WeaponData WeaponData;
#region VARIABLES_USED_FOR_THE_WEAPON
    protected GameObject bulletPrefab;
    protected int magazineSize;
    protected int currentMagazine;
    protected int bulletsXShot;
    protected bool isReloading;
    protected float reloadTimeXBullet;
    #endregion
    public virtual void Shoot()
    {
        if (isReloading)
            return;
        if (currentMagazine <= 0)
        {
            Reload();
            return;
        }
        currentMagazine -= bulletsXShot;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000))
        {
            if (hit.collider.gameObject.TryGetComponent(out Plate plate))
            {
                plate.OnPltaeHit();
            }
        }
    }
    public virtual void Reload()
    {
        if (currentMagazine == magazineSize)
            return;

        StartCoroutine(nameof(Reloading));
    }
    IEnumerator Reloading()
    {
        isReloading = true;
        for (int i = currentMagazine; i < magazineSize; i++)
        {
            yield return new WaitForSeconds(reloadTimeXBullet);
            currentMagazine++;
            Debug.Log($"reloading: {currentMagazine}/{magazineSize}");
        }

        isReloading = false;
    }
    private void Awake()
    {
        currentMagazine = WeaponData.magazineSize;
        InitializeVariables();
    }
    private void InitializeVariables()
    {
        bulletPrefab = WeaponData.bulletPrefab;
        magazineSize = WeaponData.magazineSize;
        reloadTimeXBullet = WeaponData.reloadTimeXBullet;
        bulletsXShot = WeaponData.bulletsXShot;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Shoot();
        if (Input.GetKeyDown(KeyCode.R))
            Reload();
    }
}
