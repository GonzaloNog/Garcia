using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float startPoint;
    public float endPoint;
    public float speed;
    public bool canvas;
    public Vector2 direccion;

    // Update is called once per frame
    void Update()
    {
        if (!LevelManager.instance.getGameOver())
        {
            Vector2 movimiento = direccion * speed * Time.deltaTime;

            transform.Translate(movimiento);
            if (this.transform.position.y < endPoint)
                RestartBackground();
        }
    }

    public void RestartBackground()
    {
        if(!canvas)
            transform.position = new Vector3(0,startPoint,1);
        else
            transform.position = new Vector3(this.transform.position.x,startPoint,0);
    }
}
