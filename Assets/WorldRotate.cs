using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldRotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(new Vector3 (0, (float) -1.68, 0), transform.right, 45*Time.deltaTime);
    }
}
