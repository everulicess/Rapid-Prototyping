using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateSpawneer : MonoBehaviour
{
    [SerializeField] GameObject platePrefab;
    private void Start()
    {
        InvokeRepeating(nameof(SpawnPlate), 1f, 3f);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            SpawnPlate();
    }
    public void SpawnPlate()
    {
        Vector3 platePos = new(transform.position.x, Random.Range(transform.position.y - 3f, transform.position.y + 2f), transform.position.z);
        GameObject plate = Instantiate(platePrefab, platePos, Quaternion.identity);
    }
}
