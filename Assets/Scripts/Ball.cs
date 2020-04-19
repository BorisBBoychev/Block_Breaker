using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
     public GameObject paddle;
     private Vector2 paddleToBall;
     public Rigidbody2D rigidbody;
     private bool launched = false;
     [SerializeField] private float lauchVelX = 2f;
     [SerializeField] private float lauchVelY = 15f;
    void Start()
    {
        paddleToBall = transform.position - paddle.transform.position;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!launched)
        {
            LockBallToPaddle();
            LauchBall();
        }
        
    }

    private void LauchBall()
    {
        if (Input.GetMouseButtonDown(0)) //left mouse button or touch on the screen
        {
            rigidbody.velocity = new Vector2(lauchVelX,lauchVelY);
            launched = true;
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBall;
    }
}
