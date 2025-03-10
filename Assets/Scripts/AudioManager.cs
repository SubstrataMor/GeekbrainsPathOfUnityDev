using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public float fadeTime;
    public float threshold;

    private AudioSource sound;
    private float currentVolume = -1f;
    private bool isAudioFade;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sound = GetComponent<AudioSource>();
        sound.ignoreListenerPause = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAudioFade && currentVolume < threshold)
        {
            currentVolume += threshold * (Time.unscaledDeltaTime / fadeTime);
            sound.volume = currentVolume;
        }
        if (!isAudioFade && currentVolume > 0)
        {
            currentVolume -= threshold * (Time.unscaledDeltaTime / fadeTime);
            sound.volume = currentVolume;
            if (sound.volume <= 0) sound.Stop();
        }
    }

    private void Awake()
    {
        sound = GetComponent<AudioSource>();
        if (sound == null)
        {
            Debug.LogError("No AudioSource component found on this object!");
        }
    }

    public void FadeIn()
    {
        isAudioFade = true;
        currentVolume = 0;
        PlayAudio();
    }

    public void FadeOut()
    {
        isAudioFade = false;
        currentVolume = threshold;
    }

    public void PlayAudio()
    {
        if (sound == null)
        {
            Debug.LogError("Sound is not assigned in the AudioManager!");
            return;
        }
        sound.Play();
    }
}
