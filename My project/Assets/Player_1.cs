using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_1 : Players
{
    private float AttackTime;
    private Rigidbody2D Rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= AttackTime)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                Attack();
                AttackTime = Time.time + 0.6f / 0.5f;
               
            }
        }
        if (Input.GetKeyDown(KeyCode.W) && IsGrounded())
        {
            Jump();
        }
        Movement(1);
        Flip();
    }
}
