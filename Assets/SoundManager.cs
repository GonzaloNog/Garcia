using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource music; //reproductor de sonido dedicado al sonido de fondo del juego
    public AudioSource sfx; //reproductor dedicado a reproducir sonido de efectos en momentos concretos

    public AudioClip points; //sonido que se va a emitir desde sfx cuando ganemos puntos
    public AudioClip choque; // sonido que se va a emitir desde sfx cuando nos equiboquemos de respuesta y perdamos una vida

    private void Start()
    {
        music.volume = GameManager.Instance.musicVolum; //seteamos el volumen al que tiene el game manager(modificado si queremos en el menu)
        sfx.volume = GameManager.Instance.sfxVolum; //seteamos el volumen al que tiene el game manager(modificado si queremos en el menu)
    }
    public void newSound(string sound)//esta funcion la llamamos cuando queremos ejecutar un nuevo efecto sonoro en sfx
    {
        switch (sound)//el switc determina que sonido usar segun el comando dado
        {
            case"points": // sonido cuando ganamos puntos
                sfx.clip = points; //determinamos el nuevo sonido del reproductor
                sfx.time = 0.2f; //le decimos donde arrancar a reproducir en la linea temporal
                sfx.Play(); //ejecutamos el sonido
                break;
            case "choque": //sonido cuando erramos la respuesta
                sfx.clip = choque; //determinamos el nuevo sonido del reproductor
                sfx.time = 1.1f; //le decimos donde arrancar a reproducir en la linea temporal
                sfx.Play(); //ejecutamos el sonido
                break;
        }
    }
}
