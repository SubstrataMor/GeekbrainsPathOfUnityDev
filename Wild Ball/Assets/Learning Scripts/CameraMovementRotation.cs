using UnityEngine;

public class CameraMovementRotation : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    private Vector3 offset;
    private Quaternion sideOffset;

    void Start()
    {
        offset = transform.position - playerTransform.position;
    }

    void Update()
    {

        // 1. ���������� "���������" ������� �� �������
        Vector3 targetPosition = playerTransform.position
            - playerTransform.forward * offset.z  // Z-�������� ������ �� ����������� ������� ������
            + playerTransform.up * offset.y;      // Y-�������� ������������ "�����" ������

        // 2. ������� ����������� ������
        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            5f * Time.deltaTime
        );

        // 3. ������� ������ � ������ � ��������� �������� ����
        sideOffset = Quaternion.LookRotation(
            playerTransform.position - transform.position + Vector3.down * 0.5f, // ������ �� 0.5� ���� ������
            Vector3.up
        );

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            sideOffset,
            3f * Time.deltaTime);

        transform.LookAt(playerTransform.position);
    }
}
