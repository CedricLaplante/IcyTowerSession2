using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiObjNiveau1 : MonoBehaviour
{    
    public GameObject FinishTxt;
    public GameObject RestartBotton;
    public GameObject ChangeScene2;
    //public Transform PlayerMouvement;
   

    void Start()
    {
        FinishTxt.SetActive(false);
        RestartBotton.SetActive(false);
        ChangeScene2.SetActive(false);
        //PlayerMouvement.gameObject.SetActive(true);
    }

    void OnTriggerEnter(Collider player)
    {
        //trigger de la dernière plateforme 
        if (player.gameObject.tag == "Player")
        {     
            FinishTxt.SetActive(true);
            RestartBotton.SetActive(true);
            ChangeScene2.SetActive(true);
            //PlayerMouvement.gameObject.SetActive(false);
            StartCoroutine("WaitForSec");          
        }
    }

    private IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5);        
        Destroy(gameObject);
    }
}
