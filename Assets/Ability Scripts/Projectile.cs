using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float m_Speed;

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();

        m_Speed = 5f;
    }

    private void Update()
    {
        m_Rigidbody.velocity = transform.forward * m_Speed;
    }
}
