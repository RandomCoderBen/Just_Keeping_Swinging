using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  TMPro;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
    public static Timer instence;

    public TextMeshProUGUI TimeCounter;

    float currentTime = 0f;

    float startingTime = 120f;

    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
        currentTime -= 1* Time.deltaTime;
        TimeCounter.text = currentTime.ToString ("0.0.0");

        if (currentTime <=0)
        {
            SceneManager.LoadScene(Application.loadedLevel);
        }
    }

}
