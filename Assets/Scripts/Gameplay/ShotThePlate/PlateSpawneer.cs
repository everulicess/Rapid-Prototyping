using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateSpawneer : MonoBehaviour
{
    [SerializeField] GameObject platePrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            SpawnPlate();
    }
    public void SpawnPlate()
    {
        GameObject plate = Instantiate(platePrefab, transform.position, Quaternion.identity);
        plate.transform.position += Vector3.left * 4f * Time.deltaTime;

    }
}
