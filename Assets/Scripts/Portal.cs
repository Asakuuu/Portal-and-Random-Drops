using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    CharacterController cc;
    public static bool hasTrans = false;
    private Vector3 portal1;
    public Transform portal1Trans;
    private Vector3 portal2;
    public Transform portal2Trans;

    private void Start()
    {
        portal1 = portal1Trans.position;
        portal2 = portal2Trans.position;
        cc = GetComponent<CharacterController>();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "P1" && Portal.hasTrans == false)
        {
            StartCoroutine(TeleportToPortal());
        }
        if (hit.gameObject.tag == "P2" && Portal.hasTrans == false)
        {
            StartCoroutine(TeleportToPortal1());
        }
    }
    IEnumerator TeleportToPortal()
    {
        hasTrans = true;
        cc.enabled = false;
        transform.position = new Vector3(portal1.x, 1.7f, portal1.z);
        yield return new WaitForSeconds(1f);
        cc.enabled = true;
        Debug.Log("傳送到P1");
    }

    IEnumerator TeleportToPortal1()
    {
        hasTrans = true;
        cc.enabled = false;
        transform.position = new Vector3(portal2.x, 1.7f, portal2.z);
        yield return new WaitForSeconds(1f);
        cc.enabled = true;
        Debug.Log("傳送到P2");
    }
}
