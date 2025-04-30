using UnityEngine;

public class CustomTouchInput : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 force = new Vector3(touch.position.x, 0f, touch.position.y);
            rb.AddForce(force * speed);
        }
    }
}
