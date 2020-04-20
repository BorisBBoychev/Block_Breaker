using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static Ball instance;
     public GameObject paddle;
     private Vector2 paddleToBall;
     public Rigidbody2D rigidbody;
     public bool launched = false;
     [SerializeField] private float lauchVelX = 2f;
     [SerializeField] private float lauchVelY = 15f;
    [SerializeField] private AudioClip[] ballSounds;

    private AudioSource ballSFX;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        ballSFX = GetComponent<AudioSource>();
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

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (launched)
        {
            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
            ballSFX.PlayOneShot(clip);
        }

    }
}
