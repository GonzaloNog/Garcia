using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI score; 
    public TextMeshProUGUI num1;
    public TextMeshProUGUI num2;
    public TextMeshProUGUI operador;
    public TextMeshProUGUI level;
    public GameObject[] lifes;
    public GameObject gameOver;

    void Start()
    {
        UpdateUI();
        gameOver.SetActive(false);
    }
    public void UpdateUI()
    {
        score.text = "score " + LevelManager.instance.score;
        level.text = "level " + LevelManager.instance.getLevel();
    }
    public void UpdateEcuacion(string ope, float nu1, float nu2)
    {
        num1.text = nu1.ToString();
        num2.text = nu2.ToString();
        operador.text = ope;
    }
    public void UpdateLifesUI()
    {
        for(int a = 0; a < lifes.Length; a++)
        {
            if(a < LevelManager.instance.lifes)
                lifes[a].GetComponent<Image>().color = Color.white;
            else
                lifes[a].GetComponent<Image>().color = Color.black;
        }
    }
    public void GameOver()
    {
        gameOver.SetActive(true);    
    }
}
