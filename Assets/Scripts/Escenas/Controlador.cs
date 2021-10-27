using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controlador : MonoBehaviour
{
    // Esta script esta en un controlador en la escena del menu y la del juego ControladorBotonesPyG , esta en los botones de jugar y salir del menu, y en los botones de pausa y cuando perdes y ganas

    // funcion para entrar al juego o volver a jugar otra partida.
    public void cargarEscena(string name)
    {
        SceneManager.LoadScene(name);
        Time.timeScale = 1;

    }
    // funcion para salir del juego.
    public void salir()
    {
        Application.Quit();
        Debug.Log(" Salir del juego");
    }
   
}
