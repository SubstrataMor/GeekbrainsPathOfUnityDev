using UnityEngine;
using UnityEngine.UI;

public class ImageTimer : MonoBehaviour
{
    public float maxTime;
    public bool tick;

    private Image clock;
    private float currentTime;


    void Start()
    {
        clock = GetComponent<Image>();
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        tick = false;
        currentTime += Time.deltaTime;

        if (currentTime >= maxTime)
        {
            tick = true;
            currentTime = 0;
        }

        clock.fillAmount = currentTime / maxTime;
    }
}
