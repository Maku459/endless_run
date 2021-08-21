using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveSwipe : MonoBehaviour
{
    [SerializeField]
    CharacterSwipe Input;
    [SerializeField]
    private GameObject testOBJ;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 30; // 30FPSに設定
    }

    // Update is called once per frame
    void Update()
    {

        // ひとつ目のオブジェクトを動かす処理
        float _work = Input.GetSwipeRange() * Time.deltaTime * 0.01f;

        switch (Input.GetNowSwipe())
        {
            case CharacterSwipe.SwipeDirection.LEFT:
                testOBJ.transform.localPosition = new Vector3(testOBJ.transform.localPosition.x - _work, testOBJ.transform.localPosition.y);
                break;
            case CharacterSwipe.SwipeDirection.RIGHT:
                testOBJ.transform.localPosition = new Vector3(testOBJ.transform.localPosition.x + _work, testOBJ.transform.localPosition.y);
                break;
        }
    }
}
