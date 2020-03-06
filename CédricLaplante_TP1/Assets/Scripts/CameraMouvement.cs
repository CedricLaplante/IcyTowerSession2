using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMouvement : MonoBehaviour
{
    //camera mouvement     
    private Vector3 startPos;
    private Vector3 endPos;
    public float Timer = 5f;
    public float m_Distance = 46f;
    public float lerpTime = 15f;
    public float currentLerpTime = 0f;
    public Transform PlayerPos;
    public GameObject RestartBotton;
    public GameObject DeathTxt;
    public GameObject Camera;
    
    

    private void Start()
    {
        startPos = Camera.transform.position;
        endPos = Camera.transform.position + Vector3.up * m_Distance;

        RestartBotton.SetActive(false);
        DeathTxt.SetActive(false);
        PlayerPos.gameObject.SetActive(true);      
    }

    void Update()
    {
 
        // camera lerp 
        Timer -= Time.deltaTime;
        if (Timer < 0)
        {           
            currentLerpTime += Time.deltaTime;
            if (currentLerpTime >= lerpTime)
            {
                currentLerpTime = lerpTime;            
            }
            float percentage = currentLerpTime / lerpTime;
            Camera.transform.position = Vector3.Lerp(startPos, endPos, percentage);
        }
        
        //player destroy et restart scene
        if (PlayerPos.position.y < transform.position.y - 20f)
        {
            PlayerPos.gameObject.SetActive(false);
            RestartBotton.SetActive(true);
            DeathTxt.SetActive(true);          
        }
    }
}
