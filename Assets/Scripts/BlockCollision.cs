using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BlockCollision : MonoBehaviour
{
    [SerializeField]AudioClip blockSFX;
    private Level level;

    void Start()
    {
        level = FindObjectOfType<Level>();
        level.BreakableBlocksCount();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(blockSFX , Camera.main.transform.position );
        Destroy(gameObject);
    }


}
