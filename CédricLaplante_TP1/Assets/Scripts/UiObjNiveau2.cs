using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiObjNiveau2 : MonoBehaviour
{    
    public GameObject FinishTxt;
    public GameObject RestartBotton;
    public GameObject ChangeScene1;
    //public Transform PlayerMouvement;
    
    void Start()
    {
        FinishTxt.SetActive(false);
        RestartBotton.SetActive(false);       
        ChangeScene1.SetActive(false);
        //PlayerMouvement.gameObject.SetActive(true);
    }

    void OnTriggerEnter(Collider player)
    {
        
        if (player.gameObject.tag == "Player")
        {     
            FinishTxt.SetActive(true);
            RestartBotton.SetActive(true);         
            ChangeScene1.SetActive(true);
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
