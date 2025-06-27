using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCueBallScript : MonoBehaviour
{
    Vector2 mousePos;
    Rigidbody2D rb;
    public float attackSpeed = 10f; // Optional speed multiplier

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnAttack(InputValue value)
    {
        //Vector2 attackDir = rb.position - mousePos;
        //rb.linearVelocity = attackDir * attackSpeed;
    }

    public void OnPoint(InputValue value)
    {
        Vector2 screenPos = value.Get<Vector2>();
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        mousePos = new Vector2(worldPos.x, worldPos.y);
    }
}
