using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed, timeToRevert;
    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer sr;

    private Rigidbody2D rb;

    private const float IDLE_STATE = 0;
    private const float WALK_STATE = 1;
    private const float REVERT_STATE = 2;

    private float currentState, currentTimeToRevert;

    private void Awake()
    {
        currentState = WALK_STATE;
        rb = GetComponent<Rigidbody2D>();
        currentTimeToRevert = 0;
    }

    private void Update()
    {
        Revert();
        StateController();
    }

    private void StateController()
    {
        switch (currentState)
        {
            case IDLE_STATE:
                currentTimeToRevert += Time.deltaTime;
                break;
            case WALK_STATE:
                rb.linearVelocity = Vector2.right * speed;
                break;
            case REVERT_STATE:
                sr.flipX = !sr.flipX;
                speed *= -1;
                currentState = WALK_STATE;
                break;
        }
        anim.SetFloat("Velocity", rb.linearVelocity.magnitude);
    }
    private void Revert()
    {
        if (currentTimeToRevert >= timeToRevert)
        {
            currentState = REVERT_STATE;
            currentTimeToRevert = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyStopper"))
            currentState = IDLE_STATE;
    }

}
