using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour
{
    bool pausa;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            PausarJuego();
           
        }
    }
    
    public void PausarJuego()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            Ganar.show2();
        }
        else
        {
            Time.timeScale = 1;
            Ganar.botonPerderstatic.gameObject.SetActive(false);
        }
        
    }
}
