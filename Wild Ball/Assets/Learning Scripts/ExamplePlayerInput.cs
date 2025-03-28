using UnityEngine;

namespace WildBall.InputHandler
{
    [RequireComponent(typeof(PlayerMovement))]  // ќзначает, что без этого компонента работать не будет
    public class ExamplePlayerInput : MonoBehaviour
    {
        private PlayerMovement playerMovement;
        private Vector3 movement;

        private void Awake()
        {
            playerMovement = GetComponent<PlayerMovement>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
                Debug.Log("Pressed W Button.");

            if (Input.GetMouseButtonDown(0))
                Debug.Log("Clicked left button");

            if (Input.GetButtonDown(GlobalStringVars.JUMP_AXIS))
                Debug.Log("Jump");

            float horizontal = (Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS));
            float vertical = (Input.GetAxis(GlobalStringVars.VERTICAL_AXIS));

            movement = new Vector3(horizontal, 0, vertical).normalized;
        }

        private void FixedUpdate()
        {
            playerMovement.MoveCharacter(movement);
        }
    }
}
