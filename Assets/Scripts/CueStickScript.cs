using UnityEngine;
using UnityEngine.InputSystem;

public class CueStickScript : MonoBehaviour
{
    Vector2 mousePos;
    Transform playerTransform;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Vector2 direction = (Vector2)(mousePos - (Vector2)playerTransform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        transform.position = mousePos;
    }

    public void OnPoint(InputValue value)
    {
        Vector2 screenPos = value.Get<Vector2>();
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        mousePos = worldPos;
    }
}
