using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiObj : MonoBehaviour
{
    public GameObject UiObject;
    

    void Start()
    {
        UiObject.SetActive(false);
        
    }

    void OnTriggerEnter(Collider player)
    {
        
        if (player.gameObject.tag == "Player")
        {           
            UiObject.SetActive(true);          
            StartCoroutine("WaitForSec");          
        }
    }

    private IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5);
        Destroy(UiObject);
        Destroy(gameObject);
    }
}
