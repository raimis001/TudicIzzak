using UnityEngine;

public class GPoint : MonoBehaviour
{
    [Range(0.01f, 5f)]
    public float radius = 0.1f;

    public Color color = Color.yellow;

    private void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position, radius);
        
    }
}
