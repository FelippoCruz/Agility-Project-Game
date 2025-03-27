using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
            GameManager.Instance.GameOver(isWinner: false);
        }
    }
}
