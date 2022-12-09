using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private Image ringTimer;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float startTime = 90.0f; //Time in seconds

    private float currentTime;
    private bool updateTime;    //Set this to false when game is paused

    private void Start()
    {
        currentTime = startTime;
        ringTimer = GetComponent<Image>();
        ringTimer.fillAmount = 1.0f;
        timerText = GetComponentInChildren<TextMeshProUGUI>();
        timerText.text = calcTime(currentTime);
        updateTime = true;
    }

    private void Update()
    {
        if (updateTime)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0.0f)
            {
                updateTime = false;
                currentTime = 0.0f;
                SceneManager.LoadScene("YouLose"); // once time runs out, game is over
            }
            timerText.text = calcTime(currentTime);
            float normalizedValue = Mathf.Clamp(
                     currentTime / startTime, 0.0f, 1.0f);
            ringTimer.fillAmount = normalizedValue;
        }
    }

    private string calcTime(float currentTime)
    {
        int minutes = Mathf.FloorToInt(currentTime / 60F);
        int seconds = Mathf.FloorToInt(currentTime % 60F);
        string time = minutes.ToString("0") + ":" + seconds.ToString("00");
        return time;
    }
}
