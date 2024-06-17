using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roulette : MonoBehaviour
{
    Transform m_Transform;
    // Start is called before the first frame update
    void Start()
    {
        m_Transform = GetComponent<Transform>();
    }

    public void OnSpinRoulette()
    {
        //m_Transform.rotation += new Quaternion(0,0,45f);
    }
}
