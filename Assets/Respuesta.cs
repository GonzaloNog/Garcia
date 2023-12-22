using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Respuesta : MonoBehaviour
{
    public TextMeshProUGUI resultado;
    public float resultadoNum;

    public void newResultado(float _resultado)
    {
        resultadoNum = _resultado;
        resultado.text = resultadoNum.ToString();
    }
}
