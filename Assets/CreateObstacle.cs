using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObstacle : MonoBehaviour
{
    public GameObject arrowPrefab;
    public GameObject parent;
    float span = 1.0f;
    float delta = 0;

    void Update()
    {
        this.delta += Time.deltaTime;
        if(this.delta > this.span)
        {
            this.delta = 0;
            float px = Random.Range((float) -0.05, (float) 0.07);
            float py =  Random.Range((float) -0.5, (float) 0.5);
            GameObject go = Instantiate(arrowPrefab, new Vector3(px, (float)-0.202, (float) -0.524), Quaternion.identity) as GameObject;　//InstantiateメソッドはObject型を返すが、GameObject型で受け取りたいのでキャストという強制型変換をしている
            go.transform.SetParent(parent.transform, false);
        }
    }
}