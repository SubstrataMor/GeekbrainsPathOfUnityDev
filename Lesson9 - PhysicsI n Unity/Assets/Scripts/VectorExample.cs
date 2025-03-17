using UnityEngine;

public class VectorExample : MonoBehaviour
{
    public Transform point1;
    public Transform point2;

    public float speed;
    public bool go;

    private Vector3 target;

    void Start()
    {
        Vector3 vec = new Vector3(1, 2, 4);
        //vec.x = 5;
        //vec.y = 3;
        //vec.z = 10;
        //vec.Set(3, -5, 8);
        //transform.position = vec;

        //transform.position.Set(5, 5, 5);    // �� �������� ��������,
        //transform.position.x = 5;           // ���������� ������ ��� ������.
        //vec.Set(5, 5, 5);           // ������� �������� ������������� ������,
        //transform.position = vec;   // � ����� ���� ������ ��������� � position, ����� ������� �������� ������� �������.

        //transform.position = point1.position;   // ����� ����� ��������� ������� ������� �������.

        Debug.Log(vec.magnitude);   // ����� �������.
        Debug.Log(Vector3.Distance(point1.position, point2.position));  // ��������� ����� ����� ��������.
        Debug.Log(Vector3.Angle(point1.position, point2.position));     // ����������� ���� ����� ����� ���������.
        Debug.Log(Vector3.Angle(Vector3.right, Vector3.up));            // ���� ����� �������� ������ � ����� (90 ��������).
        Debug.Log(vec);

        //transform.rotation = Quaternion.Euler(45, 45, 45);  // Euler ������������ ����� �� ���� ���� �����������.

        target = point1.position;
        transform.LookAt(target);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, point1.position, Time.deltaTime);
        //transform.position = Vector3.Lerp(transform.position, point1.position, 0.03f);   // ������ ����� ��������� ���������� � ������� �� �������� �����

        //transform.Rotate(0, 2, 0);  // ������ ���� ������������ ������ �� 2 ������� �� ��� Y.

        //transform.Rotate(0, 0, 1);

        if (go)
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);

        if (transform.position == target)
        {
            if (target == point1.position)
            {
                if (transform.rotation == Quaternion.LookRotation(point2.position - transform.position))
                {
                    target = point2.position;
                    transform.LookAt(target);
                }
                else
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(point2.position - transform.position), Time.deltaTime);
                }
            }
            else if (target == point2.position)
            {
                if (transform.rotation == Quaternion.LookRotation(point1.position - transform.position))
                {
                    target = point1.position;
                    transform.LookAt(target);
                }
                else
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(point1.position - transform.position), Time.deltaTime);
                }
                Debug.Log(transform.rotation + "ship");
                Debug.Log(Quaternion.LookRotation(point1.position - transform.position) + "target");
            }
        }
    }
}
