using UnityEngine;

public class PlayerRayCasts : MonoBehaviour
{
    [SerializeField] private float maxDistance = 10f;
    [SerializeField] private float radius = 1f;
    //[SerializeField] private Material greenMaterial;

    void Start()
    {
        Ray ray = new Ray(transform.position, Vector3.forward);
        RaycastHit hit;

        if (Physics.SphereCast(ray, radius, maxDistance))
        {

            Debug.Log("Object detected");
        }
        else Debug.Log("Object not detected");

        //if (Physics.Raycast(ray, out hit, maxDistance))
        //{
        //    Debug.Log(hit.transform.position);
        //    hit.transform.position += new Vector3(0, 2, 0);
        //    hit.transform.gameObject.GetComponent<Renderer>().material = greenMaterial;
        //    Debug.Log("Object detected");
        //}
        //else Debug.Log("Object not detected");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + maxDistance));
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(new Vector3(transform.position.x, transform.position.y, transform.position.z + maxDistance), radius);
    }
}
