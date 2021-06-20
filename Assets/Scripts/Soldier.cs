using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    public float speed = 3f;
    private Animator animator;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    private bool isFalling = true;
    private static readonly int Walking = Animator.StringToHash("Walking");
    public bool bFlipped { get; set; }
    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        animator.SetBool(Walking,false);
        if (!bFlipped)
        {
            gameObject.transform.Rotate(new Vector3(0, 180, 0));
        }
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            animator.SetBool(Walking, true);
            isFalling = false;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        } else if (other.gameObject.CompareTag("Player"))
        {

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
