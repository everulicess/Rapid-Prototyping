using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle_Weapon : WeaponBase
{
    public override void Shoot()
    {
        base.Shoot();
        Debug.Log($"THIS IS A RIFLE");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000))
        {
            if (hit.collider.gameObject.TryGetComponent(out Plate plate))
            {
                plate.OnPltaeHit();
            }
        }

        //GameObject bullet = Instantiate(bulletPrefab, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
        //bullet.GetComponent<Rigidbody>().AddForce(Vector3.forward*50f);
    }
    public override void Reload()
    {
        base.Reload();
    }
}
