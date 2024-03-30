using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelecionarPersonagem : MonoBehaviour
{
    public Sprite personagemA, personagemB;
    
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name.StartsWith("Personagem") || gameObject.name.StartsWith("Vida"))
        {
            if (gameObject.GetComponent<Image>() != null)
            {
                if (Partida.atualPersonagem == 'A')
                    gameObject.GetComponent<Image>().sprite = personagemA;
                else gameObject.GetComponent<Image>().sprite = personagemB;
            }
            else if (gameObject.GetComponent<SpriteRenderer>() != null)
            {
                if (Partida.atualPersonagem == 'A')
                    gameObject.GetComponent<SpriteRenderer>().sprite = personagemA;
                else gameObject.GetComponent<SpriteRenderer>().sprite = personagemB;
            }
        }
    }


    public void TrocarPersonagem()
    {
        if (Partida.atualPersonagem == 'A')
            Partida.atualPersonagem = 'B';
        else Partida.atualPersonagem = 'A';

        Start();
    }
}
