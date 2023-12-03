using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Ejercicio : MonoBehaviour
{
    void Start()
    {
        suma(3,3);
        suma(10, 13);
        int resultado = suma2(1,2);
        resta(4,4);
        resta2(12, 16);
        int resultado2 = resta2(1,2);
    }

    public void suma(int a, int b)
    {
        Debug.Log(a + b);
    }

    public int suma2(int a, int b)
    {
        return (a + b);
    }

    public void resta(int a, int b)
    {
        Debug.Log(a - b);
    }

    public int resta2(int a, int b)
    {
        return (a - b);
    }
}

