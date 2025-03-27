using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private bool gameStart = false;
    private float gameTime = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }

    private void Start()
    {
        UIManager.Instance.UpdateTimerText(gameTime);
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (gameStart)
        {
            gameTime += Time.deltaTime;
            UIManager.Instance.UpdateTimerText(gameTime);
        }
        //print(gameTime);
    }

    public void StartTimer()
    {
        gameStart = true;
    }

    public void StopTimer()
    {
        gameStart = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void GameOver(bool isWinner)
    {
        Time.timeScale = 0f;
        UIManager.Instance.ShowGameOverPanel(gameTime, isWinner);
    }
}
