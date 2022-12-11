using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody rb;
    private float time = 0;
    private float period = 3;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time > period)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
            time = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
