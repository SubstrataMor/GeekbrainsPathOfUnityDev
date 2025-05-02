using UnityEngine;

public class PlayerRayCast : MonoBehaviour
{
    [SerializeField] private float maxDistance = 10f;
    [SerializeField] private Material greenMaterial;

    void Start()
    {
        Ray ray = new Ray(transform.position, Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            Debug.Log(hit.transform.position);
            hit.transform.position += new Vector3(0, 2, 0);
            hit.transform.gameObject.GetComponent<Renderer>().material = greenMaterial;
            Debug.Log("Object detected");
        }
        else Debug.Log("Object not detected");
    }

    void Update()
    {

    }
}
