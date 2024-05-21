using System.Collections;
using System.Collections.Generic;
using UnityEngine;
enum Tags
{
    Projectile
}
public class Plate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime;
        Destroy(this.gameObject, 5f);
        Debug.Log(nameof(Tags.Projectile));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(nameof(Tags.Projectile)))
        {

        }
    }
}
