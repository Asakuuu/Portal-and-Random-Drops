using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - target.position;
    }

    void Update()
    {
        StartCoroutine(CameraMove());
    }

    IEnumerator CameraMove()
    {
        Vector3 targetPos = target.position;
        yield return new WaitForSeconds(0.2f);
        transform.position = Vector3.Lerp(transform.position, targetPos + offset, 5 * Time.deltaTime);
    }
}
