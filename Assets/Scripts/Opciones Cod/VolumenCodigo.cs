using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VolumenCodigo : MonoBehaviour
{
    // Este script esta en cotrolador opciones .
    public Slider slider;
    public float sliderValue;
    public Image imagenMute;
    
    // Start is called before the first frame update
    void Start()
    {
        sliderValue = PlayerPrefs.GetFloat("volumenAudio", 0.5f); // el volumen inicia en la mitad
        
        RevisarSiEstoyMute(); 

    }


    public void ChangeSlider(float valor)   // Esta funcion te permite mover el slider del volumen
    {
        sliderValue = valor;  //valor en que se encuentra la barra del volumen
        PlayerPrefs.SetFloat("volumenAudio", sliderValue); // esto acomoda la barra al valor que se le de
        RevisarSiEstoyMute(); // te informa con un icono si estoy en mute
    }
    public void RevisarSiEstoyMute() // te muestra un icono si estas muteado
    {
        if (sliderValue == 0) 
        {
            imagenMute.enabled = true;
        }
        else
        {
            imagenMute.enabled = false;
        }
    }
    void OnGUI() 
    {
        
        AudioListener.volume = sliderValue;  // como no se nos actualizaba el volumen cuando moviamos la barra y esto funciono lo dejamos asi
    }
}
    
