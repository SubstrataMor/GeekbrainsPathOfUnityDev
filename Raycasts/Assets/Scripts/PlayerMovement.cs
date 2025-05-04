using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject pointToMove;
    private NavMeshAgent meshAgent;

    private void Start()
    {
        meshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                pointToMove.transform.position = hit.point;

                meshAgent.destination = hit.point;
            }
        }
    }
}
