using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        this.gameObject.tag = nameof(Tags.Projectile);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
