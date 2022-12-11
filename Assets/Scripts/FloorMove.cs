using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMove : MonoBehaviour
{
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Floor")
        {
            if (Portal.hasTrans == true)
            {
                StartCoroutine(CanMove());
                Debug.Log("踩到地板");
            }
        }
    }

    IEnumerator CanMove()
    {
        yield return new WaitForSeconds(0.05f);
        Portal.hasTrans = false;
        Debug.Log("可以傳送");
    }
}
