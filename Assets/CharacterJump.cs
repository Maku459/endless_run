using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : MonoBehaviour
{
    [SerializeField]
    CharacterSwipe Input;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 30; // 30FPSに設定
    }

    // Update is called once per frame
    void Update () {
        var target = GameObject.Find("Character");
        
        switch (Input.GetNowSwipe())
        {
            case CharacterSwipe.SwipeDirection.LEFT:
                Debug.Log("LEFT");
                break;
            case CharacterSwipe.SwipeDirection.RIGHT:
                Debug.Log("RIGHT");
                break;
            case CharacterSwipe.SwipeDirection.TAP: 
                Debug.Log("TAP");
                iTween.MoveBy(target, iTween.Hash("y", 1f, "time", 1f, "delay", 0f, "easetype", "easeOutCubic"));
                iTween.MoveBy(target, iTween.Hash("y", -1f, "time", 0.8f, "delay", 1.0f, "easetype", "easeInCubic"));
                iTween.ScaleTo (target, iTween.Hash ("y", 0.7, "time", 1f, "delay", 0f, "easetype", "easeOutCubic"));
                iTween.ScaleTo (target, iTween.Hash ("y", 0.5, "time", 0.8f, "delay", 0.9f, "easetype", "easeInCubic"));
                iTween.ScaleTo (target, iTween.Hash ("y", 0.617, "time", 0.2f, "delay", 1.8f, "easetype", "easeInQuart"));
                break;
        }
        /*
        if (Input.GetMouseButtonDown(0))
        {
            iTween.MoveBy(target, iTween.Hash("y", 1f, "time", 1f, "delay", 0f, "easetype", "easeOutCubic"));
            iTween.MoveBy(target, iTween.Hash("y", -1f, "time", 0.8f, "delay", 1.0f, "easetype", "easeInCubic"));
            iTween.ScaleTo (target, iTween.Hash ("y", 0.7, "time", 1f, "delay", 0f, "easetype", "easeOutCubic"));
            iTween.ScaleTo (target, iTween.Hash ("y", 0.5, "time", 0.8f, "delay", 0.9f, "easetype", "easeInCubic"));
            iTween.ScaleTo (target, iTween.Hash ("y", 0.617, "time", 0.2f, "delay", 1.8f, "easetype", "easeInQuart"));
        }
        */
    }
}
