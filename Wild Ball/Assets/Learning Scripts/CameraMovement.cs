using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform ball;

    private Vector3 sideOffset = new Vector3(0f, 0.5f, 0f);

    private void Update()
    {
        // ѕолучаем направление движени€ шара (игнориру€ вертикаль)
        Vector3 ballDirection = ball.GetComponent<Rigidbody>().linearVelocity;
        ballDirection.y = 0;

        if (ballDirection.magnitude > 0.1f) // ≈сли шар движетс€
        {
            // ѕоворачиваем камеру в сторону движени€
            Quaternion targetRotation = Quaternion.LookRotation(ballDirection.normalized);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.1f);
            transform.position = ball.position + ballDirection * -2 + sideOffset;
        }
    }
}
