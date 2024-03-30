using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Temporizador : MonoBehaviour
{
    void Update()
    {
        int minutos = Mathf.FloorToInt(Partida.TempoRestante / 60);
        int segundos = Mathf.FloorToInt(Partida.TempoRestante % 60);

        gameObject.GetComponent<Text>().text = minutos.ToString("00") + ":" + segundos.ToString("00");
    }
}
