using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public UIManager manager;
    public Respuesta[] respuestas;

    public int score;
    public bool gameOver = false;
    public int lifes;

    private string operador;
    private float num1;
    private float num2;
    private float resultado;
    private int level = 1;
    private int scoreTolevel = 40;
    private bool gameover = false;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    private void Start()
    {
        newEcuacion();
    }
    public void scorePlus(int _plus)
    {
        score += _plus;
        if(score >= scoreTolevel)
        {
            scoreTolevel = scoreTolevel * 2;
            level++;
        }
        manager.UpdateUI();
    }
    public void lifesChange(int  _lifes)
    {
        lifes += _lifes;
        if(lifes > 3)
            lifes = 3;
        if(lifes == 0)
        {
            gameover = true;
            manager.GameOver();
        }
        manager.UpdateLifesUI();
    }
    public void newEcuacion()
    {
        int temp = 0;
        int correcta = 0;
        float tempResultado;
        num1 = Random.Range(-1 + level,10*level);
        num2 = Random.Range(-1 + level, 10 * level);
        temp = Random.Range(0, 4);
        correcta = Random.Range(0, 3);
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
        manager.UpdateEcuacion(operador, num1, num2);
        for(int a = 0; a < respuestas.Length; a++)
        {
            if (a == correcta)
                respuestas[a].newResultado(resultado);
            else
            {
                do
                {
                    tempResultado = getRandomResultado();
                } while (tempResultado == resultado);
                respuestas[a].newResultado(tempResultado);
            }
        }
    }
    public float getRandomResultado()
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
    public float getResultado()
    {
        return resultado;
    }
    public int getLevel()
    {
        return level;
    }
    public bool getGameOver()
    {
        return gameover;
    }
}
