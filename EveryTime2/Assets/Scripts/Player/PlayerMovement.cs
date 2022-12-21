using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Other Data")]
    public bool upsideDown;
    public bool automateFlipped;
    [HideInInspector]
    public int ud;

    [Header("Horizontal Movement")]
    public float moveSpeed = 10f;
    public Vector2 direction;
    private bool facingRight = true;

    [Header("Vertical Movement")]
    public float jumpSpeed = 15f;
    public float jumpDelay = 0.25f;
    private float jumpTimer;
    [HideInInspector]
    public bool jumping;

    [Header("Components")]
    public Rigidbody2D rb;
    public Animator animator;
    public LayerMask groundLayer;
    public GameObject characterHolder;

    [Header("Physics")]
    public float maxSpeed = 7f;
    public float linearDrag = 4f;
    public float gravity = 1f;
    public float lowFallChange;
    public float highFallChange;
    public float fallMultiplier;
    public int landedTime;
    public Vector2 velocity;
    [HideInInspector]
    public GameObject standingOn;

    [Header("Collision")]
    public bool onGround = true;
    public float groundLength = 0.6f;
    public Vector3 colliderOffset;
    [HideInInspector]
    public Vector3 defaultLocalScale;
    public float timeBeforeBounce = .1f;

    float lastOnGroundTime = 0;

    InputMaster input;

    void Awake()
    {
        if (data.type == GameType.Flipped)
        {
            upsideDown = true;
            facingRight = false;
            Flip();
        }

        defaultLocalScale = transform.localScale;

        input = new InputMaster();
        input.Player.Jump.started += ctx => JumpButtonStart();
        input.Player.Jump.canceled += ctx => JumpButtonEnd();

        if (upsideDown)
            gravity *= -1;

        ud = upsideDown ? -1 : 1;
    }

    void Update()
    {
        bool wasOnGround = onGround;
        onGround = Physics2D.OverlapBox(transform.position - new Vector3(0, defaultLocalScale.y / 2) * ud, new Vector2(defaultLocalScale.x - 0.9f, 0.2f), 0, groundLayer);

        if (!wasOnGround && onGround && Time.time - lastOnGroundTime > timeBeforeBounce)
        {
            StartCoroutine(JumpSqueeze(1.25f * defaultLocalScale.x, 0.8f * defaultLocalScale.y, 0.05f));
        }

        if (onGround)
            lastOnGroundTime = Time.time;

        

        animator.SetBool("onGround", onGround);
        direction = new Vector2(input.Player.Horizontal.ReadValue<float>() * ud, Input.GetAxisRaw("Vertical"));
    }

    void FixedUpdate()
    {
        moveCharacter(direction.x);

        if (jumpTimer > Time.time && onGround)
        {
            Jump();
        }

        modifyPhysics();
    }

    void moveCharacter(float horizontal)
    {
        //rb.AddForce(Vector2.right * horizontal * moveSpeed);
        rb.velocity += Vector2.right * horizontal * moveSpeed;

        if ((horizontal > 0 && !facingRight) || (horizontal < 0 && facingRight))
        {
            Flip();
        }
        if (Mathf.Abs(rb.velocity.x) > maxSpeed)
        {
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);
        }

        animator.SetFloat("horizontal", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("vertical", rb.velocity.y);
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(Vector2.up * jumpSpeed * ud, ForceMode2D.Impulse);
        jumpTimer = 0;
        StartCoroutine(JumpSqueeze(0.5f * defaultLocalScale.x, 1.2f * defaultLocalScale.y, 0.1f));
    }

    void modifyPhysics()
    {
        bool changingDirections = (direction.x > 0 && rb.velocity.x < 0) || (direction.x < 0 && rb.velocity.x > 0);

        if (onGround)
        {
            if (Mathf.Abs(direction.x) < 0.4f || changingDirections)
            {
                rb.drag = linearDrag;
            }
            else
            {
                rb.drag = 0f;
            }
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = gravity;
            rb.drag = linearDrag * 0.15f;

            rb.gravityScale = gravity * (jumping ? highFallChange : lowFallChange);
            if (rb.velocity.y * ud < 0)
            {
                rb.gravityScale *= fallMultiplier;
            }
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.rotation = Quaternion.Euler(0, facingRight ? upsideDown ? 180 : 0 : upsideDown ? 0 : 180, transform.rotation.eulerAngles.z);
    }

    IEnumerator JumpSqueeze(float xSqueeze, float ySqueeze, float seconds)
    {
        Vector3 originalSize = defaultLocalScale;
        Vector3 newSize = new Vector3(xSqueeze, ySqueeze, originalSize.z);
        float t = 0f;
        while (t <= 1.0)
        {
            t += Time.deltaTime / seconds;
            characterHolder.transform.localScale = Vector3.Lerp(originalSize, newSize, t);
            yield return null;
        }
        t = 0f;
        while (t <= 1.0)
        {
            t += Time.deltaTime / seconds;
            characterHolder.transform.localScale = Vector3.Lerp(newSize, originalSize, t);
            yield return null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + colliderOffset, transform.position + colliderOffset + Vector3.down * groundLength);
        Gizmos.DrawLine(transform.position - colliderOffset, transform.position - colliderOffset + Vector3.down * groundLength);
    }

    void JumpButtonStart()
    {
        jumping = true;
        jumpTimer = Time.time + jumpDelay;
    }

    void JumpButtonEnd()
    {
        jumping = false;
    }

    void OnEnable()
    {
        input.Enable();
    }

    void OnDisable()
    {
        input.Disable();
    }
}