using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovFundo : MonoBehaviour
{
    public float velocidade, limiteMin, limiteMax;
    public AudioSource audioAceleracao;
    private float audioPitch;
    internal float direcao = 0;

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale > 0)
        {
            // Determinará a movimentação para a direita ou para a esquerda
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                direcao = Mathf.Max(-1, direcao - (Time.deltaTime * 4));
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                direcao = Mathf.Min(1, direcao + (Time.deltaTime * 4));

            //Gradativamente o veículo irá parar sua movimentação
            if (direcao > 0)
                direcao = Mathf.Max(0, direcao - (Time.deltaTime * 2));
            else
                direcao = Mathf.Min(0, direcao + (Time.deltaTime * 2));

            // Modifica o posicionamento da imagem do fundo
            transform.position = new Vector3(
            transform.position.x + (velocidade * direcao * Time.deltaTime * 60),
            transform.position.y, transform.position.z);

            // Caso passe dos limites laterais,
            // a imagem será deslocada para a outra extremidade
            if (transform.position.x < limiteMin)
                transform.position = new Vector3(
                limiteMax + (transform.position.x - limiteMin),
                transform.position.y, transform.position.z);
            else if (transform.position.x > limiteMax)
                transform.position = new Vector3(
                limiteMin + (transform.position.x - limiteMax),
                transform.position.y, transform.position.z);            

            //Modificar som
            if (audioAceleracao)
            {
                float novoPitch = (Mathf.Abs(direcao) * 2 + 1);

                if (novoPitch >= audioPitch)
                    audioPitch = novoPitch;
                else audioPitch = Mathf.Max(1, audioPitch - (Time.deltaTime * 1.5f));

                audioAceleracao.pitch = audioPitch;
            }
        }
    }
}
