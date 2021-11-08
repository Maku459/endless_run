using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "hotdog")
        {
            Rigidbody rb = this.GetComponent<Rigidbody> ();  // rigidbodyを取得
            Vector3 force = new Vector3 (0.0f, 0.0f, -10.0f);  // 力を設定
            rb.AddForce (force, ForceMode.Impulse); 
            Debug.Log("addforce");
        }
    }
}
