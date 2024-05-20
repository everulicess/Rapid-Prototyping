using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow Singleton
    {
        get => singleton;
        set
        {
            if (value == null)
                singleton = null;
            else if (singleton == null)
                singleton = value;
            else if (singleton != value)
            {
                Destroy(value);
                Debug.LogError($"Only one instance of {nameof(CameraFollow)}!");
            }
        }
    }
    private static CameraFollow singleton;

    private Transform target;

    [Header("Zoom")]
    [SerializeField] private float distance = 10f;

    [Header("Speeds")]
    [SerializeField] private float smoothSpeed = 5f;

    [Header("Rotation")]
    [SerializeField] private float camXRotationt;
    [SerializeField] private float camYRotation;
    //private Vector3 camPosition;
    private void Awake()
    {
        Singleton = this;
    }
    private void OnDestroy()
    {
        if (Singleton == this)
            Singleton = null;
    }
    private void LateUpdate()
    {
        if (target == null) return;

        Vector3 pos = new(target.position.x, target.position.y + 1f, target.position.z);
        pos -= transform.forward * distance;

        transform.position = Vector3.Lerp(transform.position, pos, smoothSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(camXRotationt, camYRotation, 0f);
        this.gameObject.GetComponent<Camera>().orthographicSize = distance;
    }
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
