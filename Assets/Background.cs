using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float startPoint; //determinamos el punto de inicio del fondo
    public float endPoint; //determinamos el punto final del fondo
    public float speed; //determinamos la velocidad a la que se desplaza el fondo
    public bool canvas; //determinamos si es un canvas (lo usamos para las respuestas tambien)
    public Vector2 direccion; // determinamos en que direccion se va a mover el fondo

    // Update is called once per frame
    void Update()
    {
        if (!LevelManager.instance.getGameOver())//comprobamos que el juego siga en curso
        {
            Vector2 movimiento = direccion * speed * Time.deltaTime;//calculamos el movimiento de nuestro fondo por la velocidad dada y por el timedelta time para saver el tiempo entra frames

            transform.Translate(movimiento);//movemos efectivamente el fondo
            if (this.transform.position.y < endPoint)// si nuestra posicion en Y es menor que el punto de fin reseteamos el fondo
                RestartBackground();
        }
    }

    public void RestartBackground()
    {
        LevelManager.instance.setRespuestasControler(true);//en caso que se trate de las respuestas las prendemos nuevamente
        if(!canvas)//reseteamos el backgraund a su posicion de inicio, varia segun si es fondo o canvas de respuestas
            transform.position = new Vector3(0,startPoint,1);
        else
            transform.position = new Vector3(this.transform.position.x,startPoint,0);
    }
}
