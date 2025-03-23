using UnityEngine;

public class CubeController : MonoBehaviour
{
    private Rigidbody exampleBox;

    private void Start()
    {
        exampleBox = GetComponent<Rigidbody>();
    }

    private void Awake()
    {

    }

    private void FixedUpdate()
    {
        //exampleBox.AddForce(0, 0, -5, ForceMode.Force);
        exampleBox.linearVelocity = Vector3.back;
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("Collision detected!");
    //    Debug.Log(collision.gameObject.name);
    //}

    //private void OnCollisionExit(Collision collision)
    //{
    //    Debug.Log("Collision Exit");
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.name == "Skillbox")
    //        Debug.Log("You win!");
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.name == "Skillbox")
    //        Debug.Log("You lost!");
    //}
}
