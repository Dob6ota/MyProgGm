using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _sensitivity = 100f;
    [SerializeField] private float _speed;
    private float _xRotation = 0f;
    [SerializeField] private Transform _cameraTransform;
    private Vector2 _move;
    private Vector2 _lookInput;

    private void Update()
    {
        Move(_move);
        Look();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _move = context.ReadValue<Vector2>();
    }

    public void Move(Vector2 directionMove)
    {
        Vector3 moveDirection = (transform.forward * directionMove.y) + (transform.right * directionMove.x);

        if (moveDirection.magnitude > 1f)
        {
            moveDirection.Normalize();
        }

        transform.position += moveDirection * _speed * Time.deltaTime;
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        _lookInput = context.ReadValue<Vector2>();
    }

    private void Look()
    {
        float mouseX = _lookInput.x * _sensitivity * Time.deltaTime;
        float mouseY = _lookInput.y * _sensitivity * Time.deltaTime;

        _xRotation -= mouseY;

        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        if (_cameraTransform != null)
            _cameraTransform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);

        transform.Rotate(Vector3.up * mouseX);
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
