using UnityEngine;

public class SphereCaster : MonoBehaviour
{
    private float radius = 5f;

    void Start()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        Collider[] boxColliders = Physics.OverlapBox(transform.position, transform.localScale, Quaternion.identity);

        foreach (var collider in colliders)
        {
            Debug.Log(collider.gameObject.name);
        }

        foreach (var collider in boxColliders)
        {
            Debug.Log(collider.gameObject.name);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(transform.position, radius);
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}
