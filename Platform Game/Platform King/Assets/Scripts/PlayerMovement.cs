using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("X-axis settings")]
    [SerializeField] private float speed;
    [SerializeField] private AnimationCurve curve;

    [Header("Y-axis settings")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpOffset;
    [SerializeField] private bool isGrounded = false;

    [Header("Other settings")]
    [SerializeField] private Transform groundColliderTransform;
    [SerializeField] private LayerMask groundMask;

    private Rigidbody2D rb;
    private KnightAnimationController knightAnimation;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        knightAnimation = GetComponent<KnightAnimationController>();
    }

    private void FixedUpdate()
    {
        GroundDetector();
    }

    public void Move(float direction, bool isJumpButtonPressed)
    {
        if (isJumpButtonPressed)
        {
            Jump();
        }

        if (!isGrounded)
        {
            knightAnimation.StateChanger(KnightAnimationController.JUMP_STATE);
        }

        if (Mathf.Abs(direction) > 0.2f)
        {
            HorizontalMovement(direction);
            if (isGrounded)
                knightAnimation.StateChanger(KnightAnimationController.WALK_STATE);
        }
        else if (Mathf.Abs(direction) <= 0.2f && isGrounded)
            knightAnimation.StateChanger(KnightAnimationController.IDLE_STATE);
    }

    private void Jump()
    {
        if (isGrounded)
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    // Detecting a player's position on the ground
    private void GroundDetector()
    {
        Vector3 overlapCiclePosition = groundColliderTransform.position;
        isGrounded = Physics2D.OverlapCircle(overlapCiclePosition, jumpOffset, groundMask);
    }

    // Visualize radius in editor (for debugging only)
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(groundColliderTransform.position, jumpOffset);
    }

    private void HorizontalMovement(float direction)
    {
        rb.linearVelocity = new Vector2(curve.Evaluate(direction) * speed, rb.linearVelocity.y);
        knightAnimation.FlipSprite(direction);
    }
}
