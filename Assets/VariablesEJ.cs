using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariablesEJ : MonoBehaviour
{
    private int resultado = 0;
    public int a = 0;
    public int b = 0;

    public void plus()
    {
        resultado = (a + b);
        mensaje();
    }
    public void mensaje()
    {
        Debug.Log(resultado);
    }
    public void resta()
    {
        resultado = (a - b);
        mensaje();
    }
    public void multiplicacion()
    {
        resultado = (a * b);
        mensaje();
    }

}

