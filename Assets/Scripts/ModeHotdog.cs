using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeHotdog : MonoBehaviour
{
    float span = 10.0f;
    float delta = 0;
    
    public GameObject nextDog;
    public GameObject input;
    public GameObject world;
    public GameObject particleObject;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if(this.delta > this.span)
        {
            Instantiate(particleObject, this.transform.position, Quaternion.identity);
            world.GetComponent<WorldRotate>().ChangeSpeed();
            gameObject.SetActive (false);
            nextDog.SetActive(true);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            input.GetComponent<CalculateScore>().ScoreUp();
            Destroy(other.gameObject);
        }
    }
}
