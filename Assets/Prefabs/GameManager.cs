using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Esse aqui gerencia as interfaces de usuário
using UnityEngine.SceneManagement; // Gerencia as fases do jogo (necessário para reiniciar o nosso jogo)

public class GameManager : MonoBehaviour
{
    // Variáveis
    public Text textoDaVida, textoDaPontuacao, textoFinal;
    public int vidaMaxima = 100;
    private int pontuacaoAtual = 0;
    public Button botaoFinal; // Referência para o botão de reiniciar a partida
    public GameObject particulaExplosao;

    // Métodos
    private void Start()
    {
        Time.timeScale = 1;
        botaoFinal.gameObject.SetActive(false); // Desativo o botão de reiniciar (pois acabou de começar a partida).
        AtualizarInterfaceUsuario();
    }

    public void BotaoReiniciarJogo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void JogadorTomouDano(int valorDoDano)
    {
        //Efeito da explosao
        Instantiate(particulaExplosao, GameObject.FindObjectOfType<NaveJogador>().transform.position, particulaExplosao.transform.rotation);

        vidaMaxima -= valorDoDano;
        if (vidaMaxima <= 0)
            vidaMaxima = 0;
        AtualizarInterfaceUsuario();

        if (vidaMaxima <= 0)
        {
            botaoFinal.gameObject.SetActive(true); // Ativo o botão de reiniciar (pois morreu)
            // Jogador perdeu, morreu.
            Time.timeScale = 0f; // Comando para parar o jogo inteiro, travar tudo.
        }
    }
    public void AumentarPontuacao(int valorPontuacao)
    {
        pontuacaoAtual += valorPontuacao;
        AtualizarInterfaceUsuario();
    }

    private void AtualizarInterfaceUsuario()
    {
        textoDaPontuacao.text = "Pontuação: " + pontuacaoAtual;
        textoDaVida.text = "Vida: " + vidaMaxima;
        textoFinal.text = "";
        if (vidaMaxima <= 0)
            textoFinal.text = "Você perdeu!!! ";
    }

}
