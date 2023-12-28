using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiMenu : MonoBehaviour
{
    public Slider soundSlide; //slider que hace referencia a la barra que maneja el volumen de la musica de fondo del juego
    public Slider sfxSlider;//slider que hace referencia al volumen de los efectos sonoros 
    public void playGame() //con esto cargamos la scena 1 de la lista de niveles en build setings
    {
        SceneManager.LoadScene(1);
    }
    public void quitGame()//para cerrar la aplicacion (solo funciona en una build no en editor)
    {
        Application.Quit();
    }
    public void UpdateGM()//luego de modificar los sliders llamamos a esta funcion para modificar los contenedores de volumen (variables en gameManager)
    {
        GameManager.Instance.sfxVolum = sfxSlider.value;
        GameManager.Instance.musicVolum = soundSlide.value;
    }
}
