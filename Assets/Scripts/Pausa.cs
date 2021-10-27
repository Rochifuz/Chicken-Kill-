using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour

    // este script esta puesto en un empty object
{
    bool pausa;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // creamos en porject settings dentro de input Manager un input llamado " Pause", de valor P.
        if (Input.GetButtonDown("Pause"))   
        {
            
            PausarJuego();
           
        }
    }
    
    public void PausarJuego() // creamos una funcion que si el juego esta en funcionamiento y presionamos P, se pausay  viceversa.
    {                         
        if (Time.timeScale == 1)
        {                           // si presionamos P se pausa el juego , se activa la funcion del script Ganar que muestra los botones y se bloquea el cursos.
            Time.timeScale = 0;
            Ganar.show2();         
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {                       // Esto se ejecuta cuando presionamos de nuevo P , vuelvo a jugarse, se desactivan los botones de pausa y el cursor se bloquea
            Time.timeScale = 1;
            Ganar.botonPerderstatic.gameObject.SetActive(false);
            Ganar.botonJugarstatic.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
        
    }
}
