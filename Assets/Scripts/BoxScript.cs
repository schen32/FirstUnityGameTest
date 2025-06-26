using UnityEngine;
using UnityEngine.InputSystem;

public class BoxScript : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public Vector2 moveDir = new Vector2(0, 0);
    public SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveVelocity = new Vector3(moveDir.x, moveDir.y, 0) * moveSpeed * Time.deltaTime;
        if (moveVelocity.magnitude > 0)
        {
            transform.position += moveVelocity;
            spriteRenderer.color = Color.red;
        }
        else
        {
            spriteRenderer.color = Color.white;
        }
    }

    public void OnMove(InputValue value)
    {
        moveDir = value.Get<Vector2>();
    }
}
