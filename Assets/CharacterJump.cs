using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update () {
        var target = GameObject.Find("Character");
        if (Input.GetMouseButtonDown(0))
        {
            iTween.MoveBy(target, iTween.Hash("y", 1f, "time", 1f, "delay", 0f, "easetype", "easeOutCubic"));
            iTween.MoveBy(target, iTween.Hash("y", -1f, "time", 0.8f, "delay", 1.0f, "easetype", "easeInCubic"));
            iTween.ScaleTo (target, iTween.Hash ("y", 0.7, "time", 1f, "delay", 0f, "easetype", "easeOutCubic"));
            iTween.ScaleTo (target, iTween.Hash ("y", 0.5, "time", 0.8f, "delay", 0.9f, "easetype", "easeInCubic"));
            iTween.ScaleTo (target, iTween.Hash ("y", 0.617, "time", 0.2f, "delay", 1.8f, "easetype", "easeInQuart"));
        }
    }
}
