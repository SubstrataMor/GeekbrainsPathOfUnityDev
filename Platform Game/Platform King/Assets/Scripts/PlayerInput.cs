using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Shooter))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Shooter shooter;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        shooter = GetComponent<Shooter>();
    }

    private void Update()
    {
        MotionProcessing();
        FireProcessing();
    }

    private void MotionProcessing()
    {
        playerMovement.Move(HorizontalAxisGetter(), JumpAxisGetter());
    }

    private void FireProcessing()
    {
        if (Input.GetButtonDown(GlobalStringVars.FIRE_1))
            shooter.Shoot(HorizontalAxisGetter());
    }

    private float HorizontalAxisGetter()
    {
        float horizontalDirection = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
        return horizontalDirection;
    }

    private bool JumpAxisGetter()
    {
        bool isJumpButtonPressed = Input.GetButtonDown(GlobalStringVars.JUMP);
        return isJumpButtonPressed;
    }
}