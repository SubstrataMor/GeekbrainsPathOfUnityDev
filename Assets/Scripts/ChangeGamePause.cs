using UnityEngine;
using UnityEngine.UI;

public class ChangeGamePause : MonoBehaviour
{
    private bool isGamePaused;
    private Button pauseButton;
    private Color normalColor;

    public AudioSource sound;

    public void PauseGame()
    {
        pauseButton = GetComponent<Button>();
        ColorBlock colors = pauseButton.colors;
        normalColor = pauseButton.colors.normalColor;

        if (isGamePaused)
        {
            Time.timeScale = 1;
            colors.selectedColor = normalColor;
            pauseButton.colors = colors;
            sound.Play();
        }

        else
        {
            Time.timeScale = 0;
            colors.selectedColor = new Color(0.5882f, 0.5882f, 0.5882f);
            pauseButton.colors = colors;
            sound.Play();
            //sound.Pause();
        }

        isGamePaused = !isGamePaused;
    }
}
