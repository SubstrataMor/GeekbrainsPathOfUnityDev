using System;
using UnityEngine;
using UnityEngine.UI;

public class TimeHandler : MonoBehaviour
{
    public Text timerText;
    private double currentTime;
    public Text currentLap;

    private int lapsNumber = 0;

    public Text lapsTimeText;
    public Text previousLapTimeText;

    private bool isTimerStart;
    private double resetTime;

    void Start()
    {
        // Prints 8
        Debug.Log(Mathf.Round(7.7f));

        // Prints 14
        Debug.Log(Mathf.Round(14f));

        // Prints 6
        Debug.Log(Mathf.Round(5.5f));

        // Prints 10
        Debug.Log(Mathf.Round(10.5f));

        // Prints 6
        Debug.Log(Mathf.Round(6.5f));

        // Prints 0
        Debug.Log(Mathf.Round(-0.5f));
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerStart == true)
        {
            currentTime = Math.Round((double)Time.time - resetTime, 1);
            timerText.text = currentTime.ToString();
        }
        if (isTimerStart == false)
        {
            currentTime = 0d;
            timerText.text = currentTime.ToString();
        }
    }

    public void LapToUp()
    {
        lapsNumber += 1;
        currentLap.text = lapsNumber.ToString();
        previousLapTimeText.text = lapsTimeText.text;
        lapsTimeText.text = timerText.text;
    }

    public void StartTimer()
    {
        ResetButton(!isTimerStart);
        resetTime = Math.Round((double)Time.time, 1);
    }

    private void ResetButton(bool a)
    {
        isTimerStart = a;
    }
}
