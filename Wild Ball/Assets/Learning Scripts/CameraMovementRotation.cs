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

        // 1. ќпредел€ем "идеальную" позицию за игроком
        Vector3 targetPosition = playerTransform.position
            - playerTransform.forward * offset.z  // Z-смещение всегда по направлению взгл€да игрока
            + playerTransform.up * offset.y;      // Y-смещение относительно "верха" игрока

        // 2. ѕлавное перемещение камеры
        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            5f * Time.deltaTime
        );

        // 3. ѕоворот камеры к игроку с небольшим наклоном вниз
        sideOffset = Quaternion.LookRotation(
            playerTransform.position - transform.position + Vector3.down * 0.5f, // Ќаклон на 0.5м ниже игрока
            Vector3.up
        );

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            sideOffset,
            3f * Time.deltaTime);

        transform.LookAt(playerTransform.position);
    }
}
