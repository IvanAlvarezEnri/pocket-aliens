using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float inputHoriz;

    [SerializeField] private float horizontalSpeed = 8f;
    [SerializeField] public float maxJumpHeight = 5f;
    [SerializeField] public float maxJumpTime = 1f;
    public float jumpForce => (2f * maxJumpHeight) / (maxJumpTime / 2f);
    public float gravity => (-2f * maxJumpHeight) / Mathf.Pow(maxJumpTime / 2f, 2f);

    public bool grounded { get; private set; }
    public bool jumping { get; private set; }
    public bool falling => velocity.y < 0f && !grounded;

    private Vector2 velocity;

    private Rigidbody2D rb;
    private void Awake()
    {
       rb = GetComponent<Rigidbody2D>();
    }


    private void OnEnable()
    {
        rb.isKinematic = false;
        velocity = Vector2.zero;
        jumping = false;
    }

    private void OnDisable()
    {
        rb.isKinematic = true;
        velocity = Vector2.zero;
        jumping = false;
    }

    void Update()
    {
        HorizontalMovement();
        VerticalMovement();
    }

    private void FixedUpdate()
    {
        Vector2 position = rb.position;
        position += velocity * Time.fixedDeltaTime;

        rb.MovePosition(position);
    }

    private void HorizontalMovement()
    {
        // accelerate / decelerate
        inputHoriz = Input.GetAxis("Horizontal");
        velocity.x = Mathf.MoveTowards(velocity.x, inputHoriz * horizontalSpeed, horizontalSpeed * Time.deltaTime);

        // check if running into a wall
        if (rb.Raycast(Vector2.right * velocity.x))
        {
            velocity.x = 0f;
        }

        // flip sprite to face direction
        if (velocity.x > 0f)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else if (velocity.x < 0f)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
    }

    private void GroundedMovement()
    {
        // prevent gravity from infinitly building up
        velocity.y = Mathf.Max(velocity.y, 0f);
        jumping = velocity.y > 0f;

        // perform jump
        if (Input.GetButtonDown("Jump"))
        {
            velocity.y = jumpForce;
            jumping = true;
        }
    }

    private void ApplyGravity()
    {
        // check if falling
        bool falling = velocity.y < 0f || !Input.GetButton("Jump");
        float multiplier = falling ? 2f : 1f;

        // apply gravity and terminal velocity
        velocity.y += gravity * multiplier * Time.deltaTime;
        velocity.y = Mathf.Max(velocity.y, gravity / 2f);
    }

    private void VerticalMovement()
    {
        grounded = rb.Raycast(Vector2.down);
        ApplyGravity();
        if (grounded)
        {
            GroundedMovement();
        }

        
    }
}
