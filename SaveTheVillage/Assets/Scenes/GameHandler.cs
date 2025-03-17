using System;
using TMPro;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text _outPut;
    [SerializeField] private TMP_InputField _inputField;

    private byte value = 0;

    private void Start()
    {
        value = (byte)UnityEngine.Random.Range(0, 101);
    }

    public void onCheckClicked()
    {
        if (_inputField.text.Equals(value.ToString()))
        {
            _outPut.text = "Вы угадали!";
        }
        else if (Convert.ToInt32(_inputField.text) > value)
        {
            _outPut.text = "Загаданное число меньше.";
        }
        else if (Convert.ToInt32(_inputField.text) < value)
        {
            _outPut.text = "Загаданное число больше.";
        }
    }
}
