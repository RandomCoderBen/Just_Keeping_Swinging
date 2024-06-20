using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class LevelTimer : MonoBehaviour
{
    public static LevelTimer instence;

    public TextMeshProUGUI TimeCounter;

    private TimeSpan timePlaying;
    private bool timerGoing;

    private float elapsedTime;

    private void Awake()
    {
        instence = this;
    }

    private void Start()
    {
        TimeCounter.text = "00:00";
        timerGoing = false;

        BeginTimer();

    }

    public void BeginTimer()
    {
        timerGoing = true;

        elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        timerGoing = false;
    }

    private IEnumerator UpdateTimer()
    {
        while (timerGoing)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = timePlaying.ToString("mm':'ss'.'ff");
            TimeCounter.text = timePlayingStr;

            yield return null;
        }

    }

}
