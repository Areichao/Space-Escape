using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance { get; set; }

    private Rigidbody2D rb;
    public Transform thingToPull = null;

    private Vector2 movement;

    public bool canMove = true;
    public bool isPushing = false;

    public float speed;
    private float pullSpeed;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement = Vector2.zero;
        if (canMove) getInputs();
    }

    private void FixedUpdate()
    {
        movePlayer();
    }

    private void getInputs()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void movePlayer()
    {
        movement.Normalize();
        if(thingToPull != null)
        {
            if (Mathf.Abs(thingToPull.position.x - transform.position.x) < 1.25f && Mathf.Abs(thingToPull.position.y - transform.position.y) < 1.25f)
            {
                isPushing = true;
                pullSpeed = (speed*2) / thingToPull.gameObject.GetComponent<Rigidbody2D>().mass;
                rb.velocity = pullSpeed * movement;
                thingToPull.GetComponent<Rigidbody2D>().velocity = pullSpeed * movement * 1.2f;
            }
            else thingToPull = null;
        }
        else
        {
            isPushing = false;
            rb.velocity = speed * movement;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("Crystal")) isPushing = true;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("Crystal")) isPushing = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("Crystal")) isPushing = false;
    }

    public Rigidbody2D getRigidBody() { return rb; }

    public Transform getTransform() { return transform; }

    public Vector2 getMovement() { return movement; }
}
