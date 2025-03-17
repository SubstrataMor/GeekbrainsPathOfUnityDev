using TMPro;
using UnityEngine;

public class ButtonSample : MonoBehaviour
{
    public TMP_Text counter;
    public TMP_InputField inputField;
    int count = 0;

    public void Start()
    {
        count = Random.Range(0, 101);
    }

    public void onKlick()
    {
        //Debug.Log("Klicked! " + ++count);
        counter.text = (++count).ToString();
    }

    public void ReadText()
    {
        if (inputField.text == "")
        {
            counter.text = "¬ведите число";
        }
        else
        {
            counter.text = inputField.text;
        }
    }
}
