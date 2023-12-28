using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterControler : MonoBehaviour
{
    public float speed;//velocidad a la que se desplaza el jugador
    public GameObject[] points; //putnos guia para movernos
    public int indexStart;//determinamos en que puntos estamos
    private int indexFinish;//determinamos a que punto vamos
    private bool isMove = false;//determinamos si estamos en movimiento

    public void Start()
    {
        this.gameObject.transform.position = points[indexStart].transform.position;//seteamos nuestro veiculo en el punto de inicio
        indexFinish = indexStart;//determinamos punto final
    }   // Update is called once per frame
    void Update()
    {
        if (!LevelManager.instance.getGameOver())//mientras el juego no este en gameover podemos movernos
        {
            if (Input.GetKeyDown(KeyCode.D))//detecta el teclado para movernos en una direccion
            {
                Debug.Log("Derecha");
                if (indexFinish < 2)
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
                Vector3 newPosition = Vector3.MoveTowards(transform.position, points[indexFinish].transform.position, speed * Time.deltaTime); //nos movemos en una nueva direccion dada por los nuevos puntos

                transform.position = newPosition;

                if (this.gameObject.transform.position == points[indexFinish].transform.position)//cuando el punto se alcansa deja de moverse y queda esperando de nuevo la entrada de teclado
                {
                    isMove = false;
                    indexStart = indexFinish;
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)//comprobamos las collisones trigger contro otros collider 2d
    {
        if(collision.gameObject.tag == "respuesta")//si el objeto tiene el tag respuesta continuamos 
        {
            if (LevelManager.instance.getResultado() == collision.GetComponent<Respuesta>().resultadoNum)//si la respuesta es correcta cargamos 10 puntos
                LevelManager.instance.scorePlus(10);
            else//caso contrario perdemos una vida
                LevelManager.instance.lifesChange(-1);
            LevelManager.instance.newEcuacion();//creamos una ecuacion nueva 
        }
    }
}