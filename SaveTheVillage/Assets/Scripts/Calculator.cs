using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Calculator : MonoBehaviour
{
    [SerializeField] public Text buttonText;
    [SerializeField] public Text outPutText;
    [SerializeField] private Text firstTerm;
    [SerializeField] private Text secondTerm;
    [SerializeField] private Text lastOperand;

    public void OnKlick()
    {
        string num = buttonText.text;
        if (outPutText.text == "0") outPutText.text = num;
        else outPutText.text += num;
    }

    public void MathOperation()
    {
        string operand = buttonText.text;

        switch (operand)
        {
            case "+":
                if (firstTerm.text != "" && secondTerm.text == "") firstTerm.text = (Convert.ToDouble(firstTerm.text) + Convert.ToDouble(outPutText.text)).ToString();
                if (secondTerm.text != "")
                {
                    secondTerm.text = "";
                }
                firstTerm.text = outPutText.text;
                lastOperand.text = operand;
                outPutText.text = "0";
                break;
            case "-":
                if (firstTerm.text != "") firstTerm.text = (Convert.ToDouble(firstTerm.text) - Convert.ToDouble(outPutText.text)).ToString();
                if (secondTerm.text != "")
                {
                    secondTerm.text = "";
                }
                firstTerm.text = outPutText.text;
                lastOperand.text = operand;
                outPutText.text = "0";
                break;
            case "x":
                if (firstTerm.text != "") firstTerm.text = (Convert.ToDouble(firstTerm.text) * Convert.ToDouble(outPutText.text)).ToString();
                if (secondTerm.text != "")
                {
                    secondTerm.text = "";
                }
                firstTerm.text = outPutText.text;
                lastOperand.text = operand;
                outPutText.text = "0";
                break;
            case "/":
                if (firstTerm.text != "") firstTerm.text = (Convert.ToDouble(firstTerm.text) / Convert.ToDouble(outPutText.text)).ToString();
                if (secondTerm.text != "")
                {
                    secondTerm.text = "";
                }
                firstTerm.text = outPutText.text;
                lastOperand.text = operand;
                outPutText.text = "0";
                break;
            case "=":
                if (firstTerm.text == "" && secondTerm.text == "") break;
                else if (firstTerm.text != "" && secondTerm.text == "")
                {
                    secondTerm.text = outPutText.text;
                    if (lastOperand.text == "+") outPutText.text = (Convert.ToDouble(firstTerm.text) + Convert.ToDouble(secondTerm.text)).ToString();
                    if (lastOperand.text == "-") outPutText.text = (Convert.ToDouble(firstTerm.text) - Convert.ToDouble(secondTerm.text)).ToString();
                    if (lastOperand.text == "x") outPutText.text = (Convert.ToDouble(firstTerm.text) * Convert.ToDouble(secondTerm.text)).ToString();
                    if (lastOperand.text == "/") outPutText.text = (Convert.ToDouble(firstTerm.text) / Convert.ToDouble(secondTerm.text)).ToString();
                }
                else
                {
                    firstTerm.text = outPutText.text;
                    if (lastOperand.text == "+") outPutText.text = (Convert.ToDouble(outPutText.text) + Convert.ToDouble(secondTerm.text)).ToString();
                    if (lastOperand.text == "-") outPutText.text = (Convert.ToDouble(outPutText.text) - Convert.ToDouble(secondTerm.text)).ToString();
                    if (lastOperand.text == "x") outPutText.text = (Convert.ToDouble(outPutText.text) * Convert.ToDouble(secondTerm.text)).ToString();
                    if (lastOperand.text == "/") outPutText.text = (Convert.ToDouble(outPutText.text) / Convert.ToDouble(secondTerm.text)).ToString();
                }
                break;
            case "C":
                outPutText.text = "0";
                firstTerm.text = "";
                secondTerm.text = "";
                lastOperand.text = "";
                break;
            case "<<":
                var sb = new StringBuilder(outPutText.text);
                outPutText.text = (sb.Remove(sb.Length - 1, 1)).ToString();
                break;
        }
    }
}
