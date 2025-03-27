using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private InputSystem_Actions inputActions;

    private Vector2 moveDirection = Vector2.zero;

    private void Awake()
    {
        inputActions = new InputSystem_Actions();

        inputActions.Player.Enable();        
    }


    void Update()
    {
        moveDirection = inputActions.Player.Move.ReadValue<Vector2>();

        Vector3 directionToMove = new Vector3(moveDirection.x, 0, moveDirection.y);

        transform.Translate(directionToMove * moveSpeed * Time.deltaTime);
    }

    private void OnDisable()
    {
        inputActions.Player.Disable();
    }
}
