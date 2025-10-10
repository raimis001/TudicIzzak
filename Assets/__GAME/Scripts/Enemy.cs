using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 3;

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
