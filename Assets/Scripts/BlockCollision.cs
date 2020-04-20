using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BlockCollision : MonoBehaviour
{
    [SerializeField]AudioClip blockSFX;

    void Start()
    {
        Level.instance.breakableBlocks++;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(blockSFX , Camera.main.transform.position );
        Destroy(gameObject);
        Level.instance.destroyedBlocks++;
    }



}
