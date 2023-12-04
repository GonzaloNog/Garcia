using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VariablesEJ : MonoBehaviour
{
    private int resultado = 0;
    private int a = 0;
    private int b = 0;

    public TMP_InputField num1;
    public TMP_InputField num2;
    public TextMeshProUGUI resultadoText;
    public TextMeshProUGUI operacion;

    public void plus()
    {
        resultado = (a + b);
        mensaje();
        operacion.text = "suma";
    }
    public void mensaje()
    {
        Debug.Log(resultado);
        resultadoText.text = resultado.ToString();

        //resultadoText.text = "HOLA";
    }
    public void resta()
    {
        resultado = (a - b);
        mensaje();
        operacion.text = "resta";
    }
    public void multiplicacion()
    {
        resultado = (a * b);
        mensaje();
        operacion.text = "multiplicacion";
    }

    public void convertInput()
    {
        a = int.Parse(num1.text);
        b = int.Parse(num2.text);
    }

}

