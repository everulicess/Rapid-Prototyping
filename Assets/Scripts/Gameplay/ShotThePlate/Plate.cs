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
    [SerializeField] GameObject plate1;
    [SerializeField] GameObject plate2;
    [SerializeField] GameObject plate3;
    float plateSpeed;
    private void Start()
    {
        plateSpeed = Random.Range(3f, 7f);
        DeactivatePlates();
        int randomPlate = Random.Range(1, 3);
        PlateToSpawn(randomPlate).SetActive(true);
    }
    private void DeactivatePlates()
    {
        plate1.SetActive(false);
        plate2.SetActive(false);
        plate3.SetActive(false);
    }
    private GameObject PlateToSpawn(int _plate)
    {
        return _plate switch
        {
            1 => plate1,
            2 => plate2,
            3 => plate3,
            _ => plate1,
        };
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
        OnScoreUpdate evt = new();
        evt.GoldIncrease = 2;
        EventManager.Broadcast(evt);
    }
}
