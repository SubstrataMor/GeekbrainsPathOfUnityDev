using UnityEngine;

public class DontDestAudio : MonoBehaviour
{
    private static DontDestAudio instance; // Статическая переменная для хранения единственного экземпляра

    private void Awake()
    {
        // Проверяем, существует ли уже экземпляр DontDestAudio
        if (instance == null)
        {
            instance = this;    // Если нет, делаем этот объект единственным экземпляром
            DontDestroyOnLoad(gameObject);  // Делаем объект неуничтожаемым
        }
        else
        {
            // Если экземпляр уже существует, уничтожаем этот объект
            Destroy(gameObject);
        }
    }
}
