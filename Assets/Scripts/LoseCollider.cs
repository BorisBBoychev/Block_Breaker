﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{

    void Start()
    {
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene("GameOver");
    }
}
