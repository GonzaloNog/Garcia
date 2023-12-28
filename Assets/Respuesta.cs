using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Respuesta : MonoBehaviour
{
    public TextMeshProUGUI resultado; //texto de la UI que muestra el valor que representa 
    public float resultadoNum; //valor actual de una de las posibles respuestas

    public void newResultado(float _resultado) //generamos un nuevo resultado(cada que se conteste)
    {
        resultadoNum = _resultado;//guardamos el nuevo valor
        resultado.text = resultadoNum.ToString();//lo mostramos en la UI
    }
}
