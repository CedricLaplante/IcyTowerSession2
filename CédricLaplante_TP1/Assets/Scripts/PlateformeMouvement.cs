using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformeMouvement : MonoBehaviour
{    
    public Rigidbody m_RigidB;
    private Vector3 m_Direction;

    private void Start()
    {
        m_Direction = new Vector3(7.5f, 0f, 0f);
        m_RigidB.velocity = m_Direction;
    }

 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            m_Direction *= -1f;
            m_RigidB.velocity = m_Direction;
        }      
    }

}
