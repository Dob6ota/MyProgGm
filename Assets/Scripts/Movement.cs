using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 8f;

    [Header("Проверка земли лучом")]
    public Transform groundCheck;       
    public LayerMask groundLayer;    

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool jumpPressed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, 1, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            jumpPressed = true;
    }

    void FixedUpdate()
    {   
        float moveX = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveX * speed, rb.linearVelocity.y);

        if (jumpPressed)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpPressed = false;
        }
    }
}
