using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public static Level instance;
    public int destroyedBlocks;
    public int breakableBlocks;
    [SerializeField] GameObject levelCompleteText;


    void Start()
    {
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Update()
    {
        LevelComplete();
        LoadNextLevel();
    }

    public void LoadNextLevel()
    {
        if (Level.instance.breakableBlocks == Level.instance.destroyedBlocks)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void LevelComplete()
    {
        if (Level.instance.breakableBlocks == Level.instance.destroyedBlocks)
        {
            levelCompleteText.SetActive(true);
            Ball.instance.launched = false;
        }
    }

}
