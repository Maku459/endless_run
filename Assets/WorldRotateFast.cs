using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldRotateFast : MonoBehaviour
{
    private float[] speedArray = new float[3] {0.9f, 1.1f, 1.2f};
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = speedArray[Random.Range(0,3)];
        transform.RotateAround(new Vector3 (0, (float) -1.68, 0), transform.right, 45*Time.deltaTime*speed);
    }
}
