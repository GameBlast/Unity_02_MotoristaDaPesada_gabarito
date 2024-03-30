using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Itens : MonoBehaviour
{
    public bool presente, bombinha;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (presente)
        {
            if (other.gameObject.name.StartsWith("Personagem"))
            {
                Partida.ObjetosRestantes--;
                Partida.PontosJogador++;
                GameObject.FindGameObjectWithTag("AudioPontoGanho").GetComponent<AudioSource>().Play();

                if (Partida.ObjetosRestantes > 1)
                    GameObject.FindGameObjectWithTag("ControleItens").GetComponent<Text>().text =
                    "Faltam " + Partida.ObjetosRestantes + " presentes";
                else if (Partida.ObjetosRestantes == 1)
                    GameObject.FindGameObjectWithTag("ControleItens").GetComponent<Text>().text =
                    "Falta 1 presente";
                else
                {
                    Partida.atualControladorFase.telaGanhou.SetActive(true);
                    GameObject.FindGameObjectWithTag("AudioVitoria").GetComponent<AudioSource>().Play();
                    Time.timeScale = 0;
                    GameObject.FindGameObjectWithTag("ControleItens").SetActive(false);
                }

                Destroy(gameObject);
            }                
        }  
        else if (bombinha)
        {
            if (other.gameObject.name.StartsWith("Personagem"))
            {
                Partida.Vidas--;
                Partida.atualControladorFase.AtualizarVidas();
                Destroy(gameObject);
            }
        }
    }
}
