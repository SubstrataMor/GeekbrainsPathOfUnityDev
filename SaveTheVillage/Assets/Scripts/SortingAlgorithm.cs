using UnityEngine;
using Random = System.Random;

public class Sort : MonoBehaviour
{
    //public void Start()
    //{
    //    int[] array = SetArray(100);
    //    WriteArray(array);
    //    Debug.Log("=========================");
    //    WriteArray(SortingArray(array));
    //}

    private int[] SetArray(int lenght)
    {
        int[] array = new int[lenght];
        Random random = new Random();

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(0, 101);
        }
        return array;
    }

    private void WriteArray(int[] arr)
    {
        foreach (var item in arr)
        {
            Debug.Log(item);
        }
    }

    private int[] SortingArray(int[] arr)
    {
        double itterator = arr.Length / 2;
        int max = arr[0];
        int min = arr[0];
        int tempIndexMax = 0;
        int tempIndexMin = 0;
        int temp;
        int countMax = 0;
        int countMin = 0;

        for (int i = 0; i < itterator; i++)
        {
            for (int j = 0 + i; j < arr.Length - i - 1; j++)
            {
                if (max < arr[j + 1])
                {
                    max = arr[j + 1];
                    tempIndexMax = j + 1;
                    countMax++;
                }
                if (min > arr[j + 1])
                {
                    min = arr[j + 1];
                    tempIndexMin = j + 1;
                    countMin++;
                }
            }
            if (countMin > 0)
            {
                temp = arr[i];
                arr[i] = min;
                arr[tempIndexMin] = temp;
            }
            if (countMax > 0)
            {
                temp = arr[arr.Length - i - 1];
                arr[arr.Length - i - 1] = max;
                arr[tempIndexMax] = temp;
            }
            else
            {
                temp = arr[arr.Length - i - 1];
                arr[arr.Length - i - 1] = max;
                arr[tempIndexMin] = temp;
            }

            min = arr[i + 1];
            max = arr[i + 1];
            tempIndexMin = i + 1;
            tempIndexMax = i + 1;
            countMin = 0;
            countMax = 0;
        }
        return arr;
    }
}
