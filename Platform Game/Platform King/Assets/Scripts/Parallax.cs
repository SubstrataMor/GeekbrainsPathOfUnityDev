using UnityEngine;

public class Parallax : MonoBehaviour
{
    [Header("��������� ����������")]
    [SerializeField] private float parallaxEffectMultiplier = 0.5f; // ���� ������� (0 = ��������� ���, 1 = ��� �����)

    private Transform cameraTransform;
    private Vector3 lastCameraPosition;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
    }

    private void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(
            deltaMovement.x * parallaxEffectMultiplier,
            deltaMovement.y * parallaxEffectMultiplier,
            0
        );
        lastCameraPosition = cameraTransform.position;
    }
}
