using UnityEngine;

public class Sample : MonoBehaviour
{
    int num = 1;
    bool myBool = true;
    float myFloat = 1.5f;
    long myLong = 88L;
    ulong myULong = 045L;

    void Start()
    {
        Debug.Log(num);
        Debug.Log(myBool);
        Debug.Log(myFloat);
        Debug.Log(myLong);
        Debug.Log(myULong);
    }
}
