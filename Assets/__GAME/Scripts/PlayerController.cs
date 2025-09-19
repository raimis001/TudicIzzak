using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public InputAction controlls;

    void OnEnable()
    {
        controlls.Enable();
    }
    void OnDisable()
    {
        controlls.Disable();
    }

    Vector2 move;
    Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        move = controlls.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        body.MovePosition(body.position + move * Time.deltaTime * speed);
    }
}
