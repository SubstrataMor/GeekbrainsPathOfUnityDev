using UnityEngine;

public class MouseCasts : MonoBehaviour
{
    void Update()
    {
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                Debug.Log(hit.point);
            }
        }
    }
}
