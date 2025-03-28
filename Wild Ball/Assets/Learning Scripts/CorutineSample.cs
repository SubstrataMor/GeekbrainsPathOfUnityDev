using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CorutineSample : MonoBehaviour
{
    [SerializeField] private GameObject canvas;

    void Start()
    {
        Coroutine coroutine = StartCoroutine(Timer());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeathTrigger"))
        {
            Debug.Log("Game Over!");
            StartCoroutine(GameOverCanvas());
        }
    }

    IEnumerator Timer()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(2);
            yield return new WaitForSecondsRealtime(1);
            yield return null;

            Debug.Log(i);
        }
    }

    IEnumerator GameOverCanvas()
    {
        yield return new WaitForSeconds(3);
        Time.timeScale = 0f;
        //Destroy(gameObject);
        canvas.SetActive(true);
    }

    public void RestartScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MenuScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
