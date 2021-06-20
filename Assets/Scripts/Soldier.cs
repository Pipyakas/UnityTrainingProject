using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    public float speed = 3f;
    private Animator animator;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    private bool isFalling;
    private static readonly int Fallen = Animator.StringToHash("Fallen");

    public bool bFlipped { get; set; }
    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        animator.SetBool(Fallen,false);
        if (!bFlipped)
        {
            gameObject.transform.Rotate(new Vector3(0, 180, 0));
        }
    }

    private void FixedUpdate()
    {
        if (!isFalling)
        {
            if (bFlipped)
            {
                rb.MovePosition(Vector3.right * (Time.fixedDeltaTime * speed) + transform.position);
                return;
            }
            rb.MovePosition(Vector3.left * (Time.fixedDeltaTime * speed) + transform.position);
        }

    }
}
