using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;
using Vector3 = UnityEngine.Vector3;


public class Paddle : MonoBehaviour
{
    [SerializeField] private float minX = 1f;
    [SerializeField] private float maxX = 20f;
    [SerializeField] private float screenWidthInUnits = 22f;

    void Start()
    {
        
    }

    void Update()
    {
        float mousePosX = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector3 paddlePos = new Vector3(transform.position.x , transform.position.y , 0f);
        paddlePos.x = Mathf.Clamp(mousePosX, minX, maxX);
        transform.position = paddlePos;
    }
}
