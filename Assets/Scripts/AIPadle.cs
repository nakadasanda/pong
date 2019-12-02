﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPadle : MonoBehaviour
{
    public Ball theBall;

    public float speed = 30;

    public float lerpTweak = 2f;

    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
     void FixedUpdate()
     {
        if(theBall.transform.position.y > transform.position.y)
        {
            Vector2 dir = new Vector2(0, 1).normalized;

            rigidBody.velocity = Vector2.Lerp(rigidBody.velocity,
                dir * speed,
                lerpTweak * Time.deltaTime);
        }else if (theBall.transform.position.y < transform.position.y)
        {
            Vector2 dir = new Vector2(0, -1).normalized;

            rigidBody.velocity = Vector2.Lerp(rigidBody.velocity,
                dir * speed,
                lerpTweak * Time.deltaTime);
        } else
        {
            Vector2 dir = new Vector2(0, 0).normalized;
            rigidBody.velocity = Vector2.Lerp(rigidBody.velocity,
                dir * speed,
                lerpTweak * Time.deltaTime);
        }
    }

}
