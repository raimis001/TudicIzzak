using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public InputAction controlls;

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 15f;

    public float HP = 1f;
    public Image hpProgress;

    public Image transition;

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
        hpProgress.fillAmount = HP;

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

    void OnTriggerEnter2D(Collider2D collision)
    {
        Door door = collision.GetComponent<Door>();
        if (door)
        {
            Vector3 cam = door.targetCamera.position;
            cam.z =  Camera.main.transform.position.z;

            StartCoroutine(Transition(cam, door.targetPlayer.position));
            return;
        }

        Bullet bullet = collision.GetComponent<Bullet>();
        if (bullet && bullet.type == BulletType.Enemy)
        {
            Damage(bullet.damage);
            Destroy(collision.gameObject);
            return;
        }
    }

    IEnumerator Transition(Vector3 camera, Vector3 player)
    {
        float time = 1f;
        float current = 0f;

        Color color = transition.color;

        while (current < time)
        {
            float p = current / time;
            current += Time.deltaTime;
            color.a = p; 
            transition.color = color;

            yield return null;
        }

        color.a = 1f;
        transition.color = color;

        Camera.main.transform.position = camera;
        transform.position = player;

        yield return new WaitForSeconds(0.2f);

        current = 0f;
        while (current < time)
        {
            float p = current / time;
            current += Time.deltaTime;
            color.a = 1 - p;
            transition.color = color;

            yield return null;
        }

        color.a = 0f;
        transition.color = color;
    }
    public void Damage(float damage)
    {
        HP -= damage;
        if (HP <= 0)
            Dead();
    }
    public void Dead()
    {
        
    }
    public void Heal(float heal)
    {
        HP += heal;
        if (HP > 1f)
            HP = 1f;
    }
}