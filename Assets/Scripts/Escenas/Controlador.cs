using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controlador : MonoBehaviour
{
    public void cargarEscena(string name)
    {
        SceneManager.LoadScene(name);

    }
    public void salir()
    {
        Application.Quit();
        Debug.Log(" Salir del juego");
    }
   
}
