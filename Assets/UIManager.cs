using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI score;  //representamos el score en la UI
    public TextMeshProUGUI num1; //representamos primer numero de la operacion
    public TextMeshProUGUI num2; //representamos segundo numero de la operacion
    public TextMeshProUGUI operador; //representamos el operador de la operacion
    public TextMeshProUGUI level; // mostramos en que nivel estamos
    public TextMeshProUGUI scoreFinal; //se muestra el score luego de perder
    public GameObject[] lifes; //guardamos las iamgenes de las vidas
    public GameObject gameOver; // guardamos el contenedor de la UI GameOver para mostrar al perder

    void Start()
    {
        UpdateUI();
        gameOver.SetActive(false);//nos aseguramos que el nievel arranque con la ventana de gameover apagada
    }
    public void UpdateUI()//updateamos la data de la UI con las informacion que esta en el level manager
    {
        score.text = "score " + LevelManager.instance.score;
        level.text = "level " + LevelManager.instance.getLevel();
    }
    public void UpdateEcuacion(string ope, float nu1, float nu2)//Updateamos visualmente la nueva operacion
    {
        num1.text = nu1.ToString();
        num2.text = nu2.ToString();
        operador.text = ope;
    }
    public void UpdateLifesUI()//Updateamos la cantidad de vidas disponibles
    {
        for(int a = 0; a < lifes.Length; a++)//dependiendo la cantidad de vidas disponibles las pintamos de negro para que paresca que se perdio
        {
            if(a < LevelManager.instance.lifes)
                lifes[a].GetComponent<Image>().color = Color.white;
            else
                lifes[a].GetComponent<Image>().color = Color.black;
        }
    }
    public void GameOver()// activamos nuestra pantalla de gameover
    {
        gameOver.SetActive(true);
        scoreFinal.text = "Score: " + LevelManager.instance.score;
    }
    public void ResetGame()//recargamos este mismo nivel
    {
        SceneManager.LoadScene(1);
    }
    public void goMenu()//cargamos la scena del menu
    {
        SceneManager.LoadScene(0);
    }
}
