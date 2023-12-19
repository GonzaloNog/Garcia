using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float startPoint;
    public float endPoint;
    public float speed;
    public Vector2 direccion;

    // Update is called once per frame
    void Update()
    {
        Vector2 movimiento = direccion * speed * Time.deltaTime;

        transform.Translate(movimiento);
        if(this.transform.position.y < endPoint)
            RestartBackground();
    }

    public void RestartBackground()
    {
        transform.position = new Vector3(0,startPoint,1);
    }
}
