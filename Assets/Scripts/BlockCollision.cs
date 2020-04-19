using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BlockCollision : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }


}
