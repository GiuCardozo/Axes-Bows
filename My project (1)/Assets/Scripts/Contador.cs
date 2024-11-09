using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Contador : MonoBehaviour
{
    public GameManager VSManager;
    public TextMeshProUGUI barbaroPuntos;
    public TextMeshProUGUI arqueroPuntos;


    void Update()
    {
        barbaroPuntos.text = VSManager.puntosArquero.ToString();
        arqueroPuntos.text = VSManager.puntosBarbaro.ToString();
    }
}
