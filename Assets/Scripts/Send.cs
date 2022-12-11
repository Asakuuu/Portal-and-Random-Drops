using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Send : MonoBehaviour
{

    // 採到tf0時，停止tf1的判定、採到tf1時，停止tf0的判定 
    // false時可傳送 true時不可傳送
    // 當有任一物被停止判定時，採到地板就延遲1.5f s解除停止
    public Transform tf0;
    public Transform tf1;
    public GameObject floor;
    private bool canTransform0 = false;
    private bool canTransform1 = false;
    void Start()
    {

    }

    void Update()
    {

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.name == "floor")
        {
            StartCoroutine(DontTransform());
            Debug.Log("踩到地板");
        }
        if (canTransform0 == false)
        {
            if (hit.gameObject.name == "TF0")
            {
                Debug.Log("傳送到1");
                transform.position = tf1.position;
                canTransform1 = true;
            }
        }

        else if (hit.gameObject.name == "TF1")
        {
            Debug.Log("傳送到0");
            transform.position = tf0.position;
            canTransform0 = true;
        }
    }

    IEnumerator DontTransform()
    {
        yield return new WaitForSeconds(1.5f);
        canTransform1 = !canTransform1;
        canTransform0 = !canTransform0;
        Debug.Log("轉換bool");
    }

}
