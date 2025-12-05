using UnityEngine;

public enum BulletType
{
    Player, Enemy 
}

public class Bullet : MonoBehaviour
{
    public BulletType type;
    public float damage = 0.1f;
}
