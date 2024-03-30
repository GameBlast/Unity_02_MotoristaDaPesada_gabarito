using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControladorFase : MonoBehaviour
{
    internal bool controladorAtivo = true;
    public GameObject telaGanhou, telaPerdeu;
    public Image PlacarVida01, PlacarVida02, PlacarVida03;

    // Start is called before the first frame update
    void Start()
    {
        Partida.atualControladorFase = this;

        if (Partida.TempoRestante <= 0 || Partida.Vidas == 0)
        {
            Partida.TempoRestante = 100;
            Partida.Vidas = 3;
            Partida.PontosJogador = 0;
        }
        else
            Partida.TempoRestante += 10;

        Partida.ObjetosRestantes = GameObject.FindGameObjectsWithTag("Presente").Length;

        GameObject.FindGameObjectWithTag("ControleItens").GetComponent<Text>().text =
            "Faltam " + Partida.ObjetosRestantes + " presentes";

        Time.timeScale = 1;

        AtualizarVidas();
    }

    // Update is called once per frame
    void Update()
    {
        if (controladorAtivo)
            Partida.TempoRestante -= Time.deltaTime;

        if (Partida.TempoRestante < 0)
        {
            controladorAtivo = false;
            Partida.TempoRestante = 0;
            Perdeu();
        }
    }
    public void Pausar(bool estado)
    {
        if (estado == true)
            Time.timeScale = 0;
        else Time.timeScale = 1;
    }

    public void Encerrar()
    {
        Partida.TempoRestante = 0;
        Partida.Vidas = 0;
        SceneManager.LoadScene("MenuInicial");
    }

    public void AvancarFase()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Fase01":
                SceneManager.LoadScene("Fase02");
                break;
            case "Fase02":
                SceneManager.LoadScene("Fase03");
                break;
            case "Fase03":
                SceneManager.LoadScene("Fase01");
                break;
        }        
    }

    internal void AtualizarVidas()
    {
        PlacarVida01.gameObject.SetActive(Partida.Vidas >= 1);
        PlacarVida02.gameObject.SetActive(Partida.Vidas >= 2);
        PlacarVida03.gameObject.SetActive(Partida.Vidas == 3);

        if (Partida.Vidas <= 0)
            Perdeu();
    }

    internal void Perdeu()
    {
        telaPerdeu.SetActive(true);
        GameObject.FindGameObjectWithTag("AudioDerrota").GetComponent<AudioSource>().Play();

        string textoPlacar = "Placar final: " + Partida.PontosJogador + " presente";
        
        if (Partida.PontosJogador > 1)
            textoPlacar += "s";

        telaPerdeu.transform.Find("PlacarFinal").GetComponent<Text>().text = textoPlacar;

        Time.timeScale = 0;
        GameObject.FindGameObjectWithTag("ControleItens").SetActive(false);
    }
}
