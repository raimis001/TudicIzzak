using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 3;
    public float shootDistance = 5f;
    public float shootSpeed = 10f;
    public float shootInterval = 0.5f;

    public GameObject bulletPrefab;

    PlayerController player;
    float shootTimer = 0f;

    void Start()
    {
        player = FindFirstObjectByType<PlayerController>();
        
    }

    void Update()
    {
        if (PlayerController.IsDead)
            return;

        if (shootTimer > 0)
        {
            shootTimer -= Time.deltaTime;
            return;
        }
        float dist = Vector2.Distance(transform.position, player.transform.position);
        if (dist < shootDistance)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            Destroy(bullet, 1f);
            bullet.transform.position = transform.position;
            Vector2 direction = (player.transform.position - transform.position).normalized;

            bullet.GetComponent<Rigidbody2D>().linearVelocity = direction * shootSpeed;
            
            shootTimer = shootInterval;
        }
    }

    void Damage(int amount)
    {
        hp -= amount;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BulletPlayer"))
        { 
            Damage(1);
            Destroy(other.gameObject);
        }
    }
}
