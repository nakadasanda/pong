using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePadle : MonoBehaviour
{
    public float speed = 30;

    private void FixedUpdate()
    {
        float VertPress = Input.GetAxis("Vertical");

        GetComponent<Rigidbody2D>().velocity = new Vector2(0, VertPress) * speed;

    }
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
