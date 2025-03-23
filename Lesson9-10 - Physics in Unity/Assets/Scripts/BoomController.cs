using UnityEngine;

public class BoomController : MonoBehaviour
{
    public float timeToExplosion;
    public float power;
    public float radius;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        timeToExplosion -= Time.deltaTime;

        if (timeToExplosion <= 0)
        {
            Boom();
        }
    }

    private void Boom()
    {
        Rigidbody[] blocks = FindObjectsByType<Rigidbody>(FindObjectsSortMode.None);

        foreach (Rigidbody obj in blocks)
        {
            var dist = Vector3.Distance(transform.position, obj.transform.position);

            if (dist < radius)
            {
                Vector3 direction = obj.transform.position - transform.position;

                obj.AddForce(direction.normalized * power * (radius - dist), ForceMode.Impulse);
            }
        }

        timeToExplosion = 3;
    }
}
