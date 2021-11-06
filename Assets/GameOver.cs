using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private int count = 0;
    [SerializeField]
    GameObject GameOverUI = null;
    [SerializeField]
    GameObject Heartline;
    [SerializeField]
    Renderer renderer;// 点滅周期
    Coroutine flicker;
    bool isDamaged;
    float flickerDuration = 1.5f; //ダメージ点滅の長さ。無敵時間と共通。
    float flickerTotalElapsedTime;//ダメージ点滅の合計経過時間。
    float flickerElapsedTime;//ダメージ点滅のRendererの有効・無効切り替え用の経過時間。
    float flickerInterval = 0.075f;//ダメージ点滅のRendererの有効・無効切り替え用のインターバル。
    
    void Start() {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Damaged();
            Destroy(Heartline.transform.GetChild(0).gameObject);
            Debug.Log("Hit"); // ログを表示する
        }
    }

    void Damaged()
    {
        //ダメージ点滅中は二重に実行しない。
        if (isDamaged)
            return;
        StartFlicker();
        count++;

        if(count >= 3)
        {
            Instantiate(GameOverUI, transform.position, Quaternion.identity);
            Time.timeScale = 0;
        }
    }
    
    void StartFlicker()
    {
        flicker = StartCoroutine("Flicker");  //isDamagedで多重実行を防いでいるので、ここで多重実行を弾かなくてもOK。                  
    }
    
    IEnumerator Flicker()
    {
        isDamaged = true;
        flickerTotalElapsedTime = 0;
        flickerElapsedTime = 0;
        while (true) {
            flickerTotalElapsedTime += Time.deltaTime;
            flickerElapsedTime += Time.deltaTime;
            if (flickerInterval <= flickerElapsedTime) { //ここが被ダメージ点滅の処理。
                flickerElapsedTime = 0; 
                renderer.enabled = !renderer.enabled;//Rendererの有効、無効の反転。
            }
            if (flickerDuration <= flickerTotalElapsedTime) { //ここが被ダメージ点滅の終了時の処理。
                isDamaged = false; 
                renderer.enabled = true;//最後には必ずRendererを有効にする(消えっぱなしになるのを防ぐ)
                yield break;
            }
            yield return null;
        }
    }
//コルーチンのリセット用。
    void ResetFlicker()
    {
        if (flicker != null) {
            StopCoroutine(flicker);
            flicker = null;
        }
    }

    void Reset()
    {
        ResetFlicker();
        isDamaged = false;
        renderer.enabled = true;
    }
}