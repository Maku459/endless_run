using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterMove : MonoBehaviour
{

    private float FingerPosX0; //タップし、指が画面に触れた瞬間の指のx座標
    private float FingerPosX1; //タップし、指が画面から離れた瞬間のx座標
    private float FingerPosNow; //現在の指のx座標
    private float PosDiff = 0.5f; //x座標の差のいき値。

    private int Position = 0;
    
    [SerializeField]
    private GameObject target;
    
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 30; // 30FPSに設定
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FingerPosX0 = Input.mousePosition.x;
        }
        
        if (Input.GetMouseButton(0))
        {
            FingerPosNow = Input.mousePosition.x;
        }

        if (Input.GetMouseButtonUp(0))
        {
            FingerPosX1 = Input.mousePosition.x;
            //ジャンプの判断基準
            if (Mathf.Abs(FingerPosX0 - FingerPosX1) < PosDiff && FingerPosNow != 0)
            {
                Jump(); //別途定義したジャンプのメソッドを実行
            }
            //横移動の判断基準
            if (FingerPosNow - FingerPosX0 >= PosDiff && FingerPosNow - FingerPosX0 != 0)
            {
                if (Position < 1)
                {
                    MoveToRight(); //別途定義した右方向移動のメソッドを実行
                    Position++;
                }
            }
            else if (FingerPosX0 - FingerPosNow >= PosDiff && FingerPosNow - FingerPosX0 != 0)
            {
                if (Position > -1)
                {
                    MoveToLeft(); //別途定義した左方向移動のメソッドを実行
                    Position--;
                }
            }
        }
    }

    public void Jump()
    {
        Debug.Log("Jump");
        iTween.MoveBy(target, iTween.Hash("y", 1f, "time", 1f, "delay", 0f, "easetype", "easeOutCubic"));
        iTween.MoveBy(target, iTween.Hash("y", -1f, "time", 0.8f, "delay", 1.0f, "easetype", "easeInCubic"));
        iTween.ScaleTo (target, iTween.Hash ("y", 0.7, "time", 1f, "delay", 0f, "easetype", "easeOutCubic"));
        iTween.ScaleTo (target, iTween.Hash ("y", 0.5, "time", 0.8f, "delay", 0.9f, "easetype", "easeInCubic"));
        iTween.ScaleTo (target, iTween.Hash ("y", 0.617, "time", 0.2f, "delay", 1.8f, "easetype", "easeInQuart"));
        ResetParameter();
    }

    public void MoveToRight()
    {
        Debug.Log("MoveToRight");
        iTween.MoveBy(target, iTween.Hash("x", 0.8f, "time", 1f, "delay", 0f, "easetype", "easeOutCubic"));
        ResetParameter();
    }

    public void MoveToLeft()
    {
        Debug.Log("MoveToLeft");
        iTween.MoveBy(target, iTween.Hash("x", -0.8f, "time", 1f, "delay", 0f, "easetype", "easeOutCubic"));
        ResetParameter();
    }

    private void ResetParameter()
    {
        FingerPosX0 = 0;
        FingerPosX1 = 0;
        FingerPosNow = 0;
    }

}
