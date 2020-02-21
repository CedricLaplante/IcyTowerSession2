using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiObj : MonoBehaviour
{    
    public GameObject FinishTxt;
    public GameObject RestartBotton;
    
   

    void Start()
    {
        FinishTxt.SetActive(false);
        RestartBotton.SetActive(false);
    }

    void OnTriggerEnter(Collider player)
    {
        
        if (player.gameObject.tag == "Player")
        {
                 
            FinishTxt.SetActive(true);
            RestartBotton.SetActive(true);
            StartCoroutine("WaitForSec");          
        }
    }

    private IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5);        
        Destroy(gameObject);
    }
}
