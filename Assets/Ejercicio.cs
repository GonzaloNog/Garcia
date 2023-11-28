using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ejercicio : MonoBehaviour
{
    void Start()
    {
        suma(3,3);
        suma(10, 13);
        int resultado = suma2(1,2);
    }

    public void suma(int a, int b)
    {
        Debug.Log(a + b);
    }

    public int suma2(int a, int b)
    {
        return (a + b);
    }
}
