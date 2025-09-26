using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public InputAction controlls;

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 15f;

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
        move = controlls.ReadValue<Vector2>().normalized;

        Vector3 delta = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        delta = transform.position - delta;

        float angle = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;        
        transform.localEulerAngles = new Vector3(0, 0, angle + 90);


        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            
            bullet.transform.position = firePoint.position;

            bullet.GetComponent<Rigidbody2D>().linearVelocity = transform.up * bulletSpeed;

            Destroy(bullet, 2f);
        }
    }

    void FixedUpdate()
    {
        Vector2 dir = transform.up;

        body.MovePosition(body.position + dir * move.magnitude * Time.deltaTime * speed);

       
        
       
        
    }
}
