using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigos : MonoBehaviour
{
    // Variáveis
    public float dano;
    public float vida;

    private float velocidade;
    private Rigidbody rigidBodyInimigo;

    // Métodos
    private void Start()
    {
        // Inicializar variáveis
        rigidBodyInimigo = GetComponent<Rigidbody>();

        velocidade = Random.Range(1f, 4f); // Escolhe aleatoriamente um valor entre 1 e 4, para dar um dinamismo no jogo!
    }
    private void FixedUpdate()
    {
        rigidBodyInimigo.velocity = new Vector3(-1 * velocidade, 0f, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Método especial chamado quando o colisor atravessa outro colisor

        switch (other.gameObject.tag)
        {
            case "Parede":
                Destroy(this.gameObject);
                break;

            case "Enemy":
                Destroy(this.gameObject);
                break;

            case "Player":
                Debug.Log("Crash!");
                GameObject.FindObjectOfType<GameManager>().JogadorTomouDano((int)dano);
                Destroy(this.gameObject);
                break;

            default:
               
                break;

            case "Asteroide":
                break;
        }

    }
}
