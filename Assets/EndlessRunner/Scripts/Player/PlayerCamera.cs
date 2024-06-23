using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] Transform target;
    float yDistance = 0.765f;
    float zDistance = -1.75f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = new(0, target.position.y + yDistance, target.position.z + zDistance);
        transform.position = targetPos;
    }
}
