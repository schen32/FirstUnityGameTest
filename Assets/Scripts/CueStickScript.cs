using UnityEngine;
using UnityEngine.InputSystem;

public class CueStickScript : MonoBehaviour
{
    public float hitSpeed = 10.0f;
    public GameObject aimObject;
    GameObject createdObject;
    Vector2 mousePos;
    Transform playerTransform;
    Transform target;
    Rigidbody2D rb;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        target = playerTransform;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (rb.linearVelocity.magnitude == 0)
        {
            Vector2 direction = mousePos - (Vector2)target.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            rb.position = mousePos;
        }
    }
    public void OnAttack(InputValue value)
    {
        if (createdObject == null)
        {
            createdObject = Instantiate(aimObject, mousePos, Quaternion.identity);
            target = createdObject.transform;
        }
        else
        {
            Vector2 direction = (Vector2)target.position - mousePos;
            rb.linearVelocity = direction * hitSpeed;

            Destroy(createdObject);
            createdObject = null; // Clear the reference!
            target = playerTransform;
        }
    }

    public void OnPoint(InputValue value)
    {
        Vector2 screenPos = value.Get<Vector2>();
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        mousePos = worldPos;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        rb.linearVelocity = Vector2.zero;
    }
}
