using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform ball;

    private Vector3 offset;
    private Quaternion sideOffset;

    private void Awake()
    {
        offset = transform.position - ball.position;
    }

    private void Update()
    {
        transform.position = ball.position + offset;

        // �������� ����������� �������� ���� (��������� ���������)
        Vector3 ballDirection = ball.GetComponent<Rigidbody>().linearVelocity;
        ballDirection.y = 0;

        if (ballDirection.magnitude > 0.1f) // ���� ��� ��������
        {
            // ������������ ������ � ������� ��������
            Quaternion targetRotation = Quaternion.LookRotation(ballDirection.normalized);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.1f);
        }
    }
}
