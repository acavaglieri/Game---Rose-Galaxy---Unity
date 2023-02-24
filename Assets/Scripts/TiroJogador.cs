using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroJogador : MonoBehaviour
{
    /* Anda pra direita, e se bater em algo, destrói o que bateu e ele mesmo */

    public AudioClip somTiro; // Passo uma variável de referência para o som que vai tocar!
    public AudioClip somExplosaoNave, somExplosaoAsteroide;
    public GameObject particulaExplosao;

    private Rigidbody rigidBodyLaser;

    private void Start()
    {
        AudioSource.PlayClipAtPoint
            (
                somTiro,                                // Qual é o som que será tocado
                Camera.main.transform.position,         // Posição que será tocado
                0.1f                                      // Volume (que vai de 0 até 1f)
            );

        rigidBodyLaser = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rigidBodyLaser.velocity = new Vector3(9f, 0f, 0f);
    }

    // Para destruir o tiro e o que ele bateu
    private void OnTriggerEnter(Collider other)
    {
        // Sempre que este objeto entrar na area de outro objeto, este código é executado
        if (other.gameObject.tag == "Asteroide")
        {
            // SOM da explosão do asteroide
            AudioSource.PlayClipAtPoint(somExplosaoAsteroide, Camera.main.transform.position, 0.2f);
            GameObject.FindObjectOfType<GameManager>().AumentarPontuacao(5);
            Destroy(other.gameObject); // Destroi o asteroide
            //Efeito da explosao
            Instantiate(particulaExplosao, other.transform.position, particulaExplosao.transform.rotation);
        }
        if (other.gameObject.tag == "Enemy")
        {
            // SOM da explosão da nave inimiga
            AudioSource.PlayClipAtPoint(somExplosaoNave, Camera.main.transform.position, 0.5f);

            // JOGADOR GANHA PONTUACAO
            GameObject.FindObjectOfType<GameManager>().AumentarPontuacao(10);

            Destroy(other.gameObject); // Destruo a nave inimiga
            //Efeito da explosao
            Instantiate(particulaExplosao, other.transform.position, particulaExplosao.transform.rotation);
        }

        if (other.gameObject.tag != "Player")
            Destroy(this.gameObject); // Destruo eu mesmo
    }
}
