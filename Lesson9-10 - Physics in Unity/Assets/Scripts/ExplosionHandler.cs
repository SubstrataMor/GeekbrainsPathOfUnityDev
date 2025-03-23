using UnityEngine;

public class ExplosionHandler : MonoBehaviour
{
    public float explosionRadius;
    public float explosionForce;
    public float tossingModifier;
    public LayerMask affectedLayers;

    void Start()
    {
        Explosion();
    }

    void Explosion()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, affectedLayers);

        foreach (var item in colliders)
        {
            Rigidbody rb = item.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, tossingModifier);
            }
        }

        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
