using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Paddle : MonoBehaviour
{
    [SerializeField] private float minX = 1f;
    [SerializeField] private float maxX = 20f;
    [SerializeField] private float screenWidthInUnits = 22f;

    private GameStatus gameStatus;
    private Ball ball;

    void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        ball = FindObjectOfType<Ball>();
    }

    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePos;
        
    }

    private float GetXPos()
    {
        if (gameStatus.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        }

        return Input.mousePosition.x / Screen.width * screenWidthInUnits;
    }
}
