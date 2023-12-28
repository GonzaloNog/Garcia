using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; //variable statica que guarda nuestro gamemanager para llamarlo desde cualquier clase
    public float musicVolum; // guardamos volumen d ela musica
    public float sfxVolum; // guardamos volumen de los efectos sonoros

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; //determinamos la instancia como este mismo objeto si no se encontro otro gamemanager guardado
        }
        else
        {
            Destroy(gameObject);//si ya existia algo en el Instance destruimos este gameManager
        }
        DontDestroyOnLoad(gameObject);//mantenemos la existencia del gamemanager entre scenas
    }
}
