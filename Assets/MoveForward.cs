using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class MoveForward : MonoBehaviour
{
    Rigidbody2D body;
    [SerializeField] private float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    public void StartMoving()
    {
        body.velocity = transform.up * speed;
    }
    public void StopMoving()
    {
        body.velocity = Vector2.zero;
    }
}
