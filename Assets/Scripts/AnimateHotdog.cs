using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateHotdog : MonoBehaviour
{
    public float maxAngle = 1.0f;
    
    float span = 3.0f;
    float delta = 0;

    Quaternion startRotation;
    private float[] sinArray = new float[10] {0.1f, 0.2f, 0.3f, 0.4f, 0.5f, 0.6f, 0.7f, 0.8f, 0.9f, 1.0f};

    // Start is called before the first frame update
    void Start()
    {
        startRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            float sin = sinArray[Random.Range(0, 10)];
            transform.rotation = startRotation * Quaternion.Euler(sin * maxAngle, 0f, 0f);
        }
    }
}
