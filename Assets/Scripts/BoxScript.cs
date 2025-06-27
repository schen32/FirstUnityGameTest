using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class BoxScript : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHeight;
    public float rotationSpeed;
    public float gravityScale;
    public float fallingGravityScale;
    Vector2 moveDir;
    bool canJump;
    SpriteRenderer m_spriteRenderer;
    Rigidbody2D m_rigidbody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveSpeed = 500.0f;
        jumpHeight = 2000.0f;
        rotationSpeed = 10.0f;
        gravityScale = 10.0f;
        fallingGravityScale = 20.0f;
        moveDir = Vector2.zero;
        canJump = false;
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_rigidbody.gravityScale = gravityScale;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveVelocityX = moveDir.x * moveSpeed * Time.deltaTime;
        float moveVelocityY = moveDir.y * jumpHeight * Time.deltaTime;
        m_rigidbody.linearVelocityX = moveVelocityX;
        m_rigidbody.angularVelocity = moveVelocityX * -rotationSpeed;
        if (moveVelocityY > 0 && canJump)
        {
            m_rigidbody.linearVelocityY = moveVelocityY;
            m_spriteRenderer.color = Color.red;
            canJump = false;
        }

        if (m_rigidbody.linearVelocityY >= 0)
        {
            m_rigidbody.gravityScale = gravityScale;
        }
        else
        {
            m_rigidbody.gravityScale = fallingGravityScale;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
        m_spriteRenderer.color = Color.white;
    }

    public void OnMove(InputValue value)
    {
        moveDir = value.Get<Vector2>();
    }
}
