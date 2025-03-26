using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Collider))]
public class CoinPickup : MonoBehaviour
{
    private Animator animator;
    private bool isCollected = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        // Убедитесь, что коллайдер настроен как триггер
        GetComponent<Collider>().isTrigger = true;
    }

    // Для 3D-объектов
    void OnTriggerEnter(Collider other)
    {
        if (!isCollected && other.CompareTag("Player"))
        {
            PlayCoinAnimation();
        }
    }

    void PlayCoinAnimation()
    {
        isCollected = true;
        animator.SetTrigger("Collect"); // Запускаем анимацию
        Destroy(gameObject, 2f); // Уничтожаем монетку после анимации (настройте время под свою анимацию)
    }
}