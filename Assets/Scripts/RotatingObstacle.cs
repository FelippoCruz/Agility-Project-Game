using UnityEngine;

public class RotatingObstacle : Obstacle
{
    [SerializeField] private float rotationSpeed;

    private void Update()
    {
        float rotationY = rotationSpeed * Time.deltaTime;
        transform.Rotate(0, rotationY, 0);
    }
}
