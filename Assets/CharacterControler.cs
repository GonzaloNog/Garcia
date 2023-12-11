using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour
{
    public float speed;
    public GameObject[] points;
    public int indexStart;
    private int indexFinish;
    private bool isMove = false;

    public void Start()
    {
        this.gameObject.transform.position = points[indexStart].transform.position;
        indexFinish = indexStart;
    }   // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))//detecta el teclado para movernos en una direccion
        {
            Debug.Log("Derecha");
            if(indexFinish < 2)
            {
                isMove = true;
                indexFinish++;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))//detecta el teclado para movernos en una direccion
        {
            Debug.Log("Izquierda");
            if (indexFinish > 0)
            {
                isMove = true;
                indexFinish--;
            }
        }
        if (isMove)//si se ingresa una tecla isMove se pone en true, nos vamos a mover hasta el siguiente punto
        {
            Vector3 newPosition = Vector3.MoveTowards(transform.position, points[indexFinish].transform.position,speed * Time.deltaTime);

            transform.position = newPosition;

            if(this.gameObject.transform.position == points[indexFinish].transform.position)//cuando el punto se alcansa deja de moverse y queda esperando de nuevo la entrada de teclado
            {
                isMove = false;
                indexStart = indexFinish;
            }
        }
    }
}