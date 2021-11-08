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
    public GameObject world;
    public GameObject particleStar;
    public GameObject particleSmoke;

    void Start() {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            Debug.Log(other.name);
            Instantiate(particleStar, this.transform.position, Quaternion.identity);
            if (other.name == "ketchup(Clone)")
            {
                isKetchup = true;
                Destroy(other.gameObject);
            } 
            else if (other.name == "mustard(Clone)")
            {
                isMustard = true;
                Destroy(other.gameObject);
            }
            else
            {
                isBread = true;
                Destroy(other.gameObject);
            }

            if (isKetchup && isMustard && isBread)
            {
                ChangeChara();
            }
        }
    }

    void ChangeChara()
    {
        Instantiate(particleSmoke, this.transform.position, Quaternion.identity);
        world.GetComponent<WorldRotate>().ChangeSpeed();
        gameObject.SetActive (false);
        nextDog.SetActive(true);
    }
    
}