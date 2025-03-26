using System.Linq;
using UnityEngine;

public class StarController : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //animator.SetFloat("Rest", 10);
        //animator.SetBool("IsRest", true);
        animator.SetTrigger("Collect");
        Debug.Log("collected");
    }

    public void DestroySomething()
    {
        Destroy(FindObjectsByType<MeshFilter>(FindObjectsSortMode.None).FirstOrDefault()?.gameObject);
        // ���������� ������ ������ ��������� ������ � MeshFilter

        //Destroy(FindObjectOfType<MeshFilter>().gameObject);

        //Destroy(FindFirstObjectByType<MeshFilter>().gameObject);
        // ���������� ������ ����, ����� ������������ ���������� ����� FindObjectsByType
    }
}
