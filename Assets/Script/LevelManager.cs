using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance; //guardamos la isntancia de nuestro levelmanager para modificarlo desde cualquier otro script
    public UIManager manager;//referencia al controlador de UI
    public Respuesta[] respuestas;//array con las respuestas disponibles
    public GameObject respuestasControler;//objeto que guarda el canvas de las respuestas
    public SoundManager sound; //referencia al controlador de audio

    public int score; //puntuacion acumulada
    public int lifes; //controlamos la cantidad de vidas

    private string operador;//controlamos el operador de la ecuacion
    private float num1;//guardamos primer numero operacion
    private float num2;//guardamos segundo numero operacion
    private float resultado;//guardamos el resultado correcto de la operacion
    private int level = 1;//guardamos en que nivel estamos
    private int scoreTolevel = 40;//determinamos la cantidad de puntos que tenemos que tener para pasar a otro nivel
    private bool gameover = false;//controlamos si el game sigue en curso
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    private void Start()
    {
        newEcuacion();//generamos una nueva operacion
    }
    public void scorePlus(int _plus)//sumamos puntos nuevos
    {
        setRespuestasControler(false);//apagamos las respuestas
        sound.newSound("points");//sonido de puntos
        score += _plus;//sumamos los nuevos puntos
        if(score >= scoreTolevel)//si tenemos mas puntos que lso requeridos para subir de nivel aumentamos nuestro nivel ya gregamos un *2 a los puntos de nuevo nivel
        {
            scoreTolevel = scoreTolevel * 2;
            level++;
        }
        manager.UpdateUI();//upodateamos la UI con lso nuevos cambios
    }
    public void lifesChange(int  _lifes)//controlamos la perdida de vida
    {
        setRespuestasControler(false);
        sound.newSound("choque");
        lifes += _lifes;
        if(lifes > 3)
            lifes = 3;
        if(lifes == 0)// si nos quedamos sin vidas perdemos
        {
            gameover = true;
            manager.GameOver();
        }
        manager.UpdateLifesUI();//updateamos la UI de vidas
    }
    public void newEcuacion()// generamos una nueva oepracion
    {
        int temp = 0;
        int correcta = 0;
        float tempResultado;
        num1 = Random.Range(-1 + level,10*level);//se generan los random teniendo encuenta el nivel para el rango de dificultad
        num2 = Random.Range(-1 + level, 10 * level);
        temp = Random.Range(0, 4);//determinamos de forma aleatoria el tipo de operacion
        correcta = Random.Range(0, 3);//determinamos de forma aleatoria dondes e guarda la respuesta correcta
        switch (temp)
        {
            case 0:
                operador = "-";
                resultado = num1 - num2;
                break;
            case 1:
                operador = "+";
                resultado = num1 + num2;
                break;
            case 2:
                operador = "/";
                resultado = num1 / num2;
                break;
            case 3:
                operador = "*";
                resultado = num1 * num2;
                break;
        }
        manager.UpdateEcuacion(operador, num1, num2);//mostramos visualmente la nueva operacion
        for(int a = 0; a < respuestas.Length; a++)
        {
            if (a == correcta)
                respuestas[a].newResultado(resultado);//guardamos la respuesta correcta
            else
            {
                do
                {
                    tempResultado = getRandomResultado();//generamos un resultado aleatorio que sea distinto al correcto
                } while (tempResultado == resultado);
                respuestas[a].newResultado(tempResultado);
            }
        }
    }
    public float getRandomResultado()//se genera un resultado aleatoria teniendo encuenta los mismos parametros para buscar nuemeros algo similares a la respuesta correcta
    {
        switch (operador)
        {
            case "-":
                return Random.Range(-1 + level, 10 * level) - Random.Range(-1 + level, 10 * level);
            case "+":
                return Random.Range(-1 + level, 10 * level) + Random.Range(-1 + level, 10 * level);
            case "/":
                return Random.Range(-1 + level, 10 * level) / Random.Range(-1 + level, 10 * level);
            case "*":
                return Random.Range(-1 + level, 10 * level) * Random.Range(-1 + level, 10 * level);
        }
        return 0f;
    }
    public float getResultado()//optenemos el resultado
    {
        return resultado;
    }
    public int getLevel()//optenemos el nivel
    {
        return level;
    }
    public bool getGameOver()//optenemos el gameover
    {
        return gameover;
    }
    public void setRespuestasControler(bool _res)//cuandos e resetea la posicion de las respuestas las reposicionamos
    {
        for(int a = 0; a < respuestas.Length; a++)
        {
            respuestas[a].gameObject.SetActive(_res);
        }
        respuestasControler.SetActive(_res);
    }
}
