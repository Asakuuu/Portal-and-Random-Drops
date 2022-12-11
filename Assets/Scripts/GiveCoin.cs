using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveCoin : MonoBehaviour
{
    public GameObject coin;
    public GameObject giveCoin;
    private Vector3 gc;

    void Start()
    {
        gc = giveCoin.transform.position;
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            for (int i = 0; i < 5; i++)
            {

                float a = Random.Range(gc.x - 0.5f, gc.x + 0.5f);
                float b = Random.Range(gc.y - 0.5f, gc.y + 0.5f);
                float c = Random.Range(gc.z - 0.5f, gc.z + 0.5f);
                float d = Random.Range(0, 360);
                float e = Random.Range(0, 360);
                float f = Random.Range(0, 360);
                Instantiate(coin, new Vector3(a, b, c), new Quaternion(d, e, f, 0));
            }
            this.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
