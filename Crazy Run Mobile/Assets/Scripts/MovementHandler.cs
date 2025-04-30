using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    public InputHandler InputHandler;
    [SerializeField] private float ballSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (InputHandler == null) Debug.Log("Input Handler не назначен.");
    }

    private void MoveBall()
    {
        if (InputHandler.IsThereTouchOnScreen())
        {
            Vector2 currentDeltaPos = InputHandler.GetTouchDeltaPosition();
            currentDeltaPos *= ballSpeed;
            Physics.gravity = new Vector3(currentDeltaPos.x, Physics.gravity.y, currentDeltaPos.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveBall();
    }
}
