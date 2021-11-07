using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObstacle : MonoBehaviour
{
    public GameObject arrowPrefab;
    public GameObject parent;
    float span = 3.0f;
    private float[] spanArray = new float[3] {2.0f, 3.0f, 4.0f};
    float delta = 0;

    void Update()
    {
        this.delta += Time.deltaTime;
        if(this.delta > this.span)
        {
            this.delta = 0;
            float[] pxArray = new float[3] {-1.0f, 0, 1.0f};
            var px = pxArray[Random.Range(0,3)];
            GameObject go = Instantiate(arrowPrefab, new Vector3(px,(float)-3.38,(float)-5.57), Quaternion.identity) as GameObject;　//InstantiateメソッドはObject型を返すが、GameObject型で受け取りたいのでキャストという強制型変換をしている
            Vector3 size = go.transform.localScale; //現在の大きさを代入
            size = size * 10;
            go.transform.localScale = size;
            go.transform.SetParent(parent.transform, true);
            span = spanArray[Random.Range(0,3)];
        }
    }
}