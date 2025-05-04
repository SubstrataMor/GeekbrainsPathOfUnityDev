using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerJump : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Physics.Raycast(transform.position, Vector3.down, 1.1f))
        {
            rb.AddForce(new Vector3(0, 3, 0), ForceMode.Impulse);
        }
    }
}
