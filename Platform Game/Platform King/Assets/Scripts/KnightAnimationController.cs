using UnityEngine;

public class KnightAnimationController : MonoBehaviour
{
    public const float IDLE_STATE = 0;
    public const float WALK_STATE = 1;
    public const float JUMP_STATE = 2;
    public const float DEATH_STATE = 3;
    public const float ATTACK_STATE = 4;
    public const float ROLL_STATE = 5;

    [SerializeField] private Transform firePoint;
    private float currentState;

    private Animator anim;
    private SpriteRenderer sp;
    private Vector3 defaultFirePointPosition;
    private float reversFirePointPosition;

    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        defaultFirePointPosition = firePoint.localPosition;
        reversFirePointPosition = firePoint.localPosition.x * -1;
    }

    private void Update()
    {
        StateController();
    }

    private void StateController()
    {
        switch (currentState)
        {
            case IDLE_STATE:
                ResetAllTriggers();
                anim.SetTrigger("Idle");
                anim.SetBool("IsJump", false);
                break;
            case WALK_STATE:
                ResetAllTriggers();
                anim.SetTrigger("Run");
                anim.SetBool("IsJump", false);
                break;
            case JUMP_STATE:
                ResetAllTriggers();
                anim.SetTrigger("Jump");
                anim.SetBool("IsJump", true);
                break;
            case DEATH_STATE:
                break;
            case ATTACK_STATE:
                break;
            case ROLL_STATE:
                break;
        }
    }

    public void StateChanger(float state)
    {
        currentState = state;
        //ResetAllTriggers();
    }

    public void FlipSprite(float direction)
    {
        if (direction > 0)
        {
            sp.flipX = false;
            firePoint.localPosition = defaultFirePointPosition;
        }
        if (direction < 0)
        {
            sp.flipX = true;
            firePoint.localPosition = new Vector3(reversFirePointPosition, firePoint.localPosition.y, 0);
        }
    }

    private void FlipFirePointPosition()
    {

    }

    private void ResetAllTriggers()
    {
        foreach (var param in anim.parameters)
        {
            if (param.type == AnimatorControllerParameterType.Trigger)
            {
                anim.ResetTrigger(param.name);
            }
        }
    }
}
