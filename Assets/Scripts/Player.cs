using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10;
    public Transform firePoint;
    public GameObject bullet;
    private IEnumerator shooting;
    public static CharacterController cc;

    void Start()
    {
        shooting = KeepShooting();
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(shooting);
        }
        else
        {
            StopCoroutine(shooting);
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h, 0, v);

        if (dir.magnitude > 0.1f)
        {
            float faceAngle = Mathf.Atan2(h, v) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0, faceAngle, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.3f);
        }

        if (!cc.isGrounded)
        {
            dir.y = -9.8f * 30 * Time.deltaTime;
        }

        cc.Move(dir * speed * Time.deltaTime);
    }

    void Fire()
    {
        Instantiate(bullet, firePoint.transform.position, transform.rotation);
    }

    IEnumerator KeepShooting()
    {
        while (true)
        {
            Fire();

            yield return new WaitForSeconds(0.5f);
        }
    }
}