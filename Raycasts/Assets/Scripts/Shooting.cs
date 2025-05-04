using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Camera _camera;
    void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = _camera.ScreenPointToRay(new Vector3(_camera.pixelWidth * 0.5f, _camera.pixelHeight * 0.5f, 0));

            if (Physics.Raycast(ray, out hit))
            {
                hit.transform.gameObject.GetComponent<Rigidbody>().useGravity = true;
            }
        }
    }
}
