using UnityEngine;

public class ChelickController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        animator.SetFloat("Velocity", rb.linearVelocity.magnitude);
    }
}
