using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntos : MonoBehaviour
{
    public float puntos;

    void OnGUI()
    {
        GUI.contentColor = Color.black;
        GUI.Label(new Rect(100, 10, 90, 40), "Puntaje Jugador: " + puntos);
    }
}
