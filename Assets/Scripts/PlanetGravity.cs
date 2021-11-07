using System;
using UnityEngine;
using System.Collections;

public class PlanetGravity : MonoBehaviour
{
    public GameObject planet;// 引力の発生する星
    public float accelerationScale; // 加速度の大きさ

    public void Start()
    {
       　planet = GameObject.Find("World");
    }

    void FixedUpdate () {
        // 星に向かう向きの取得
        var direction = planet.transform.position - transform.position;
        direction.Normalize();

        // 加速度与える
        GetComponent<Rigidbody>().AddForce(accelerationScale * direction, ForceMode.Acceleration);
    }
}