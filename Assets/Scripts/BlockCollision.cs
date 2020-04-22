using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BlockCollision : MonoBehaviour
{
    [SerializeField]AudioClip blockSFX;
    [SerializeField] private GameObject destroyVFX;
    [SerializeField] private int maxHits;
    private GameStatus gameStatus;
    [SerializeField] private int hitsReceived;
    [SerializeField] private Sprite[] hitSprites;

    void Start()
    {
        if (gameObject.tag == "Breakable")
        {
            Level.instance.breakableBlocks++;

        }
        gameStatus = FindObjectOfType<GameStatus>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.tag == "Breakable")
        {
            hitsReceived++;
            maxHits = hitSprites.Length + 1;
            if (hitsReceived >= maxHits)
            {
                DestroyBlock();
            }
            else
            {
                ShowNextHitSprite();
            }
            
        }
       
    }

    private void ShowNextHitSprite()
    {
        GetComponent<SpriteRenderer>().sprite = hitSprites[hitsReceived-1];
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(blockSFX, Camera.main.transform.position);
        Destroy(gameObject);
        Level.instance.destroyedBlocks++;
        gameStatus.IncreaseScore();
        TriggerVFX();
    }

    void TriggerVFX()
    {
        if (gameObject.tag == "Breakable")
        {
            var sparkles = Instantiate(destroyVFX, transform.position, transform.rotation);
            Destroy(sparkles, 1f);
        }
        
    }



}
