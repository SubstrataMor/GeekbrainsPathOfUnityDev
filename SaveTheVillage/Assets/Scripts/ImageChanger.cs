using UnityEngine;
using UnityEngine.UI;

public class ImageChanger : MonoBehaviour
{
    public Sprite newSprite;
    public Sprite oldSprite;
    //public AudioClip track;

    private Image img;
    //private AudioSource audio;
    private Sprite currentSprite;

    void Start()
    {
        img = GetComponent<Image>();
        //audio = GetComponent<AudioSource>();
        //audio.Play();
    }

    public void ChangeSprite()
    {
        currentSprite = newSprite;
        img.sprite = currentSprite;
        img.SetNativeSize();
        newSprite = oldSprite;
        oldSprite = currentSprite;
    }

    public void ChangeColor()
    {
        img.color = new Color(0.1f, 0.2f, 0.4f);
    }

    public void ChangeSoundPlay()
    {
        //if (audio.isPlaying) audio.Pause();
        //else audio.Play();
    }

    public void ChangeTrack()
    {
        //audio.clip = track;
        //audio.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
