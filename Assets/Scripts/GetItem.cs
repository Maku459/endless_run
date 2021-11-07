using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    private int count = 0;
    private bool isKetchup = false;
    private bool isMustard = false;
    private bool isBread = false;

    public GameObject nextDog;
    public GameObject input;

    void Start() {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            Debug.Log(other.name);
            if (other.name == "ketchup(Clone)")
            {
                isKetchup = true;
                Destroy(other.gameObject);
                Debug.Log("isKetchup");
            } 
            else if (other.name == "mustard(Clone)")
            {
                isMustard = true;
                Destroy(other.gameObject);
                Debug.Log("isMustard");
            }
            else
            {
                isBread = true;
                Destroy(other.gameObject);
                Debug.Log("isBread");
            }

            if (isKetchup && isMustard && isBread)
            {
                ChangeChara();
            }
        }
    }

    void ChangeChara()
    {
        gameObject.SetActive (false);
        nextDog.SetActive(true);
        input.GetComponent<WorldRotate>().speed = 1.2f;
    }
    
}