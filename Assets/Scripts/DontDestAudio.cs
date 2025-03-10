using UnityEngine;

public class DontDestAudio : MonoBehaviour
{
    private static DontDestAudio instance; // ����������� ���������� ��� �������� ������������� ����������

    private void Awake()
    {
        // ���������, ���������� �� ��� ��������� DontDestAudio
        if (instance == null)
        {
            instance = this;    // ���� ���, ������ ���� ������ ������������ �����������
            DontDestroyOnLoad(gameObject);  // ������ ������ ��������������
        }
        else
        {
            // ���� ��������� ��� ����������, ���������� ���� ������
            Destroy(gameObject);
        }
    }
}
