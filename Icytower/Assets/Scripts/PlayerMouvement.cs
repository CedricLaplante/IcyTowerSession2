using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    public Rigidbody RB;
    public float JumpForce = 11.5f; 
    private bool Jump = false;   
    private bool InAir = false; 
    private Vector3 m_Déplacement;

    // mouvement (jump, translate) 
    private void Update()
    {
        m_Déplacement = RB.velocity;
        //Gauche, Droite 
        if (InAir == false)
        {
            if (Input.GetKey(KeyCode.A))
            {
                m_Déplacement.x = -10f;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                m_Déplacement.x = 10f;
            }
            else
            {
                m_Déplacement.x *= 0.2f;
            }
        }           
        RB.velocity = m_Déplacement;

   
        
        //raycast du millieux
        bool PlayerRaycast = Physics.Raycast(transform.position, new Vector3(0f, -1f, 0f), 0.8f);
        Debug.DrawRay(transform.position, new Vector3(0f, -1f, 0f) * 0.8f, Color.red);
        //raycast gauche
        Vector3 raycastGauche = transform.position + new Vector3(-0.5f, 0f, 0f);
        bool LeftRaycast = Physics.Raycast(raycastGauche, new Vector3(0f, -1f, 0f), 0.8f);
        Debug.DrawRay(raycastGauche, new Vector3(0f, -1f, 0f) * 0.8f, Color.red);
        //raycast droite
        Vector3 raycastDroit = transform.position + new Vector3(0.5f, 0f, 0f);
        bool rightRaycast = Physics.Raycast(raycastGauche, new Vector3(0f, -1f, 0f), 0.8f);
        Debug.DrawRay(raycastDroit, new Vector3(0f, -1f, 0f) * 0.8f, Color.red);

        Jump = LeftRaycast || PlayerRaycast || rightRaycast;

        //Le jump 
        if (Jump == true && Input.GetKeyDown(KeyCode.Space))
        {
            RB.AddForce(Vector3.up * JumpForce , ForceMode.Impulse);
            Jump = false;
            
        }        
    }
 
    private void OnCollisionEnter(Collision collision)
    {        
        InAir = false;          
    }
    private void OnCollisionExit(Collision collision)
    {       
        InAir = true;            
    }    
}
