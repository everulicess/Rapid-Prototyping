using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    [SerializeField] protected GameObject bulletPrefab;
    public virtual void Shoot()
    {
        Debug.Log($"Bullet has been shot using: {this.gameObject.name}");
    }
    public virtual void Reload()
    {

    }
    private void Start()
    {

    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Shoot();
    }
}
