using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Collider))]
public class CoinPickup : MonoBehaviour
{
    private Animator animator;
    private bool isCollected = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        // ���������, ��� ��������� �������� ��� �������
        GetComponent<Collider>().isTrigger = true;
    }

    // ��� 3D-��������
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
        animator.SetTrigger("Collect"); // ��������� ��������
        Destroy(gameObject, 2f); // ���������� ������� ����� �������� (��������� ����� ��� ���� ��������)
    }
}