using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_2 : Players
{
    private float AttackTime;
    

    // Start is called before the first frame update
    void Start()
    {
        AttackTime = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= AttackTime)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Attack();
                AttackTime = Time.time + 0.6f / 0.5f;

            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded())
        {
            Jump();
        }
        Movement(2);
        Flip();

    }

}

