using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaAI : MonoBehaviour
{
    public float speed = 1f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            speed *= -1;
        }
        else if(collision.gameObject.CompareTag("Enemy")){
            speed *= -1;
        }
    }
}
