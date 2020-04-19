using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ColorChanger : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    float timeLeft;
    public Color newColor;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void ChangerOfColors()
    {
        if (spriteRenderer != null)
        {
            if (timeLeft <= Time.deltaTime)
            {
                spriteRenderer.material.color = newColor;

                newColor = new Color(Random.value, Random.value, Random.value);
                timeLeft = 1.0f;
            }
            else
            {
                spriteRenderer.material.color =
                    Color.Lerp(spriteRenderer.material.color, newColor, Time.deltaTime / timeLeft);

                timeLeft -= Time.deltaTime;
            }

        }
    }

    void FixedUpdate()
    {
        ChangerOfColors();
    }

}
