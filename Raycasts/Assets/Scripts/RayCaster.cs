using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private float maxDist = 5f;
    [SerializeField] private LayerMask layer;

    void Start()
    {
        Ray ray = new Ray(transform.position, Vector3.forward);

        // Interacts with objects lying in the specified layer
        if (Physics.Raycast(ray, maxDist, layer))
        {
            Debug.Log("Hit!");
        }
    }
}
