using UnityEngine;

public class PlatformFinish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.StopTimer();
            GameManager.Instance.GameOver(isWinner: true);
        }
    }
}
