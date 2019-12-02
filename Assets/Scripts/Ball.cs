using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{

    public float speed = 30;

    private Rigidbody2D rigidBody;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        rigidBody.velocity = Vector2.right * speed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //LeftPaddle or RightPaddle
        if ((col.gameObject.name == "LeftPaddle" ) ||
            (col.gameObject.name == "RightPaddle"))
        {

            HandlHitPaddle(col);
            SoundManeger.Instance.playOneShot(SoundManeger.Instance.hitPaddleBloop);
        }

        //WallTop or WallBottom
        if ((col.gameObject.name == "WallTop") ||
            (col.gameObject.name == "WallBottom"))
        {
            SoundManeger.Instance.playOneShot(SoundManeger.Instance.wallBloop);
        }
        //LeftGaol or RightGaol

        if ((col.gameObject.name == "LeftGaol") ||
            (col.gameObject.name == "RightGaol"))
        {
            if (col.gameObject.name == "LeftGaol")
            {
                IncreaseTextUIScore("RightScoreUI");
            }else if (col.gameObject.name == "RightGaol")
            {
                IncreaseTextUIScore("LeftScoreUI");
            }

            SoundManeger.Instance.playOneShot(SoundManeger.Instance.gaolBloop);

            transform.position = new Vector2(0, 0);
        }

        // TODO update Score Point UI

        
    }
    void HandlHitPaddle(Collision2D col)
    {
        float y = BallHitPadleWhere(transform.position,
            col.transform.position,
            col.collider.bounds.size.y);

        Vector2 dir = new Vector2();

        if(col.gameObject.name == "LeftPaddle" )
        {
            dir = new Vector2(1, y).normalized;
        }

        if (col.gameObject.name == "RightPaddle")
        {
            dir = new Vector2(-1, y).normalized;
        }

        rigidBody.velocity = dir * speed;

        
    }
    float BallHitPadleWhere( Vector2 ball, Vector2 paddle, float paddleHeight)
    {
        return (ball.y - paddle.y) / paddleHeight;
    }

    void IncreaseTextUIScore(string textUIName)
    {
        var textUIComp = GameObject.Find(textUIName).GetComponent<Text>();

        int score = int.Parse(textUIComp.text);

        score++;

        textUIComp.text = score.ToString();

    }
}
