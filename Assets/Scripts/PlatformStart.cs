using UnityEngine;

public class PlatformStart : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("exiting start area");
            GameManager.Instance.StartTimer();
        }
    }
}
