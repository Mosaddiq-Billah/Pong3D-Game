using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_script : MonoBehaviour
{
    public float speed = 8f;
    Rigidbody rb;
    public bool isPlayer = true;
    private Transform ball;
    public float offset = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ball = GameObject.FindGameObjectWithTag("ball").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer == true)
        {
            player();
        }

        else
        {
            movebycomputer();
        }
        /*if (Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.S))
        {
            rb.velocity = Vector3.zero;
        }*/

    }

    private void movebycomputer()
    {
        if (this.ball.position.z > transform.position.z + offset)
        {
            rb.velocity = Vector3.forward * speed;
        }

        else if (this.ball.position.z < transform.position.z - offset)
        {
            rb.velocity = Vector3.back * speed;
        }

        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    void player()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = Vector3.forward * speed;
        }
        else
        {

        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            rb.velocity = Vector3.back * speed;
        }
        else
        {

        }
    }
}
