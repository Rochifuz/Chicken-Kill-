using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VolumenCodigo : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image imagenMute;
    
    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = slider.value;
        RevisarSiEstoyMute();

    }


    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("volumenAudio", sliderValue);
        RevisarSiEstoyMute();
    }
    public void RevisarSiEstoyMute()
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
        //Create a horizontal Slider that controls volume levels. Its highest value is 1 and lowest is 0
        sliderValue = GUI.HorizontalSlider(new Rect(25, 25, 200, 60), sliderValue, 0.0F, 1.0F);
        //Makes the volume of the Audio match the Slider value
        AudioListener.volume = sliderValue;
    }
}
    
