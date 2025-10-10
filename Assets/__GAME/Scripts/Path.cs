using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public Transform actor;

    [Range(0f, 10f)]
    public float speed = 1f;

    public int type = 0;

    public List<Transform> nodes;

    int currentNode = 1;

    void Start()
    {
        actor.position = nodes[0].position;
    }

    void Update()
    {
        Vector2 delta = Vector2.MoveTowards(actor.position, nodes[currentNode].position, speed * Time.deltaTime);
        actor.position = delta;

        if (Vector2.Distance(actor.position, nodes[currentNode].position) <= Mathf.Epsilon)
        {
            currentNode++;
            if (currentNode == nodes.Count)
            {
                currentNode = 0;
            }
        }
    }
}
