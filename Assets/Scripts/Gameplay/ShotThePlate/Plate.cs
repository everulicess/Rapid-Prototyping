using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
enum Tags
{
    Projectile
}
public class Plate : MonoBehaviour
{
     
    float plateSpeed;
    private void Start()
    {
        plateSpeed = Random.Range(3f, 7f);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * plateSpeed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(nameof(Tags.Projectile)))
            Destroy(this.gameObject);
    }
    public void OnPltaeHit()
    {
        Destroy(this.gameObject);
        OnPlateBrokenEvent evt = new();
        evt.amountToIncrease = 2;
        EventManager.Broadcast(evt);
    }
}
