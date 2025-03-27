using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI bestTimeText;
    [SerializeField] private TextMeshProUGUI GameOverText;

    [SerializeField] private GameObject GameOverPanel;

    [SerializeField] private Button RestartButton;


    private void Awake()
    {
        Instance = this;
        GameOverPanel.SetActive(false);

        RestartButton.onClick.AddListener(GameManager.Instance.RestartGame);
    }

    public void UpdateTimerText(float time)
    {
        TimeSpan timeInSeconds = TimeSpan.FromSeconds(time);
        timerText.text = string.Format("{0:00}:{1:00}", timeInSeconds.Seconds, timeInSeconds.Milliseconds);
    }

    public void ShowGameOverPanel(float bestTime, bool isWinner)
    {
        if (isWinner == true)
        {
            GameOverText.text = "You Won!";
            GameOverText.color = Color.green;
        }
        else
        {
            GameOverText.text = "You Lose!";
            GameOverText.color = Color.red;
        }

        TimeSpan timeInSeconds = TimeSpan.FromSeconds(bestTime);
        bestTimeText.text = "Best time - " + string.Format("{0:00}:{1:00}", timeInSeconds.Seconds, timeInSeconds.Milliseconds);

        
        GameOverPanel.SetActive(true);
    }
}
