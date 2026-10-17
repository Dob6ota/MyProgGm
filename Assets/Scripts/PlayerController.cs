using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Vector2 _direction;

    private void Update()
    {
        Move(_direction);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _direction = context.ReadValue<Vector2>();
    }

    public void Move(Vector2 directionMove)
    {
        Vector3 direction = new Vector3(directionMove.x, 0 , directionMove.y);
        transform.position += direction * _speed * Time.deltaTime;
    }

    public void OnJump(InputAction.CallbackContext context)
    {

    }

    public void OnCrouch(InputAction.CallbackContext context)
    {

    }

    public void OnAttack(InputAction.CallbackContext context)
    {

    }
}
