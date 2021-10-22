using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controlador : MonoBehaviour
{
    public void cargarEscena(string name)
    {
        SceneManager.LoadScene(name);
        Time.timeScale = 1;

    }
    public void salir()
    {
        Application.Quit();
        Debug.Log(" Salir del juego");
    }
   
}
