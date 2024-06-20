using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    public TextMeshProUGUI scoreText;

    public GameObject GateCover;

    


    void Start()
    {
       // LevelTimer.instence.BeginTimer();  // Activates Timer code upon level start.
    }

   
    void Update()
    {
        this.scoreText.text = String.Format("Coins: {0}/6", score);
    }
    public void UpdateScore(int increment)
    {
        this.score += increment;

        if (score >= 6)  // Once all coins have been collected this code gets triggered.
        {
            Destroy(GateCover);
        }
    }

    

}
