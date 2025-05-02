using UnityEngine;

public class PlayerReycastAll : MonoBehaviour
{
    [SerializeField] private float maxDistance = 10f;

    void Start()
    {
        RaycastHit[] raycastHits;

        raycastHits = Physics.RaycastAll(transform.position, Vector3.forward, maxDistance);

        Debug.DrawRay(transform.position, Vector3.forward * maxDistance, Color.red, 10000);

        foreach (var hit in raycastHits)
        {
            Debug.Log(hit.transform.position);
        }
    }

    void Update()
    {

    }
}
