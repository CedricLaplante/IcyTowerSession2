using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouvement : MonoBehaviour
{
    //camera mouvement
    //public float UpMove = 2.3f;
    public float Timer = 5f;
    public GameObject Camera;
    private Vector3 startPos;
    private Vector3 endPos;
    public float m_Distance = 30f;
    public float lerpTime = 15f;
    public float currentLerpTime = 0f;


    private void Start()
    {
        startPos = Camera.transform.position;
        endPos = Camera.transform.position + Vector3.up * m_Distance;
    }

    void Update()
    {      
        Timer -= Time.deltaTime;
        if (Timer < 0)
        {
            //transform.Translate(0f, UpMove * Time.deltaTime, 0f);

            currentLerpTime += Time.deltaTime;
            if (currentLerpTime >= lerpTime)
            {
                currentLerpTime = lerpTime;
            }
            float percentage = currentLerpTime / lerpTime;
            Camera.transform.position = Vector3.Lerp(startPos, endPos, percentage);
        } 
    }
}
