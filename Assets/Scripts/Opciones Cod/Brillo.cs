using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Brillo : MonoBehaviour
{
    public Scrollbar scroll;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //brilloSlider.value = brillo;
    }
   // public void UpdateBrillo(float nuevoBrillo)
    //{
      //  brillo = nuevoBrillo;

   // }
    public void CambiarBrillo()
    {
        RenderSettings.ambientIntensity = scroll.value;
    }
    
}
