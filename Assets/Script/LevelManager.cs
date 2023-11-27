using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public int score;
    public bool gameOver = false;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        scorePlus(10);
    }
    void Start()
    {
        Debug.Log("score: " + score);
    }
    public void scorePlus(int _plus)
    {
        score += _plus;
    }
}
