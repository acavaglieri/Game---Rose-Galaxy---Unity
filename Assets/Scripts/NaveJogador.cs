using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveJogador : MonoBehaviour
{
    // Variáveis
    public float velocidade;
    public float velocidadeGiro;
    public float vida;
    public int municao;

    private float velocidadeInputX = 0f;
    private float velocidadeInputZ = 0f;
    private Rigidbody rigidBodyNave;

    public GameObject tiro;

    // Funções
    private void Start()
    {
        // Inicialização de variáveis

        rigidBodyNave = GetComponent<Rigidbody>(); /* Chamada interna da Unity que busca dentro do objeto
                                                    que se está trabalhando (neste caso a Nave X-Wing) por
                                                    um componente específico (neste caso um RigidBody) */
    }
    private void Update()
    {
        // Captura dos inputs (entradas) do usuário / jogador
        velocidadeInputX = Input.GetAxis("Horizontal"); /* Esta chamada interna captura se uma pessoa está
                                                        apertando as setas do teclado ou o W/S */
        velocidadeInputZ = Input.GetAxis("Vertical"); // Teclas A/D

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("O usuário quer atirar!");
            // Mais pra frente iremos codificar o disparo aqui!
            // A HORA CHEGOU!!!!
            Instantiate
                (
                    tiro,
                    new Vector3(transform.position.x + 1, 0, transform.position.z),
                    tiro.transform.rotation
                );
        }
    }
    private void FixedUpdate()
    {
        // Atualização dos atributos físicos
        rigidBodyNave.velocity = new Vector3
                                    (
                                        velocidadeInputX,   // Velocidade no eixo X
                                        0,                  // Velocidade no eixo Y
                                        velocidadeInputZ    // Velocidade no eixo Z
                                    ) * velocidade; /* Eu faço a multiplicação final pela velocidade pública para
                                                    fazer um ajuste fino da velocidade da nave */

        // Fixar (travar) a rotação!
        rigidBodyNave.rotation = Quaternion.Euler
                                    (
                                        rigidBodyNave.velocity.x * velocidadeGiro,
                                        90f,
                                        rigidBodyNave.velocity.z * velocidadeGiro
                                    );
    }
}
