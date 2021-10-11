using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDogs : MonoBehaviour
{
    public GameObject otherDog;
    public GameObject parent;
    float dogSpan = 10.5f;
    private float[] dogSpanArray = new float[3] {8.5f, 10.5f, 12.5f};
    float delta = 0;

    void Update()
    {
        this.delta += Time.deltaTime;
        if(this.delta > this.dogSpan)
        {
            this.delta = 0;
            float[] pxArray = new float[3] {-1.0f, 0, 1.0f};
            var px = pxArray[Random.Range(0,3)];
            GameObject dog = Instantiate(otherDog, new Vector3(px,(float)-3.84,(float)-5.63), Quaternion.Euler(-120f, 0f, 8f)) as GameObject;　//InstantiateメソッドはObject型を返すが、GameObject型で受け取りたいのでキャストという強制型変換をしている
            Vector3 size = dog.transform.localScale; //現在の大きさを代入
            size = size * 10;
            dog.transform.localScale = size;
            dog.transform.SetParent(parent.transform, true);
            dogSpan = dogSpanArray[Random.Range(0,3)];
        }
    }
}